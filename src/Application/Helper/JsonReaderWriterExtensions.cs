using System.Diagnostics;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Xml;

namespace Microsoft.Extensions.DependencyInjection.Helper;

public class JsonReaderWriterExtensions
{
    const int BufferSize = 8192;
    private static readonly Microsoft.IO.RecyclableMemoryStreamManager manager = new();

    public static Stream CreateTemporaryStream() =>
        // Create some temporary stream to hold the deserialized binary data.  
        // Could be a FileStream created with FileOptions.DeleteOnClose or a Microsoft.IO.RecyclableMemoryStream
        // File.Create(Path.GetTempFileName(), BufferSize, FileOptions.DeleteOnClose);
        manager.GetStream();

    public static T DeserializeModelWithStreams<T>(Stream inputStream) where T : new() =>
        PopulateModelWithStreams(inputStream, new T());

    public static T PopulateModelWithStreams<T>(Stream inputStream, T model)
    {
        ArgumentNullException.ThrowIfNull(inputStream);
        ArgumentNullException.ThrowIfNull(model);

        var type = model.GetType();

        using (var reader = JsonReaderWriterFactory.CreateJsonReader(inputStream, XmlDictionaryReaderQuotas.Max))
        {
            // TODO: Stream-valued properties not at the root level.
            if (reader.MoveToContent() != XmlNodeType.Element)
                throw new XmlException();
            while (reader.Read() && reader.NodeType != XmlNodeType.EndElement)
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        var name = reader.LocalName;
                        // TODO:
                        // Here we could use use DataMemberAttribute.Name or other attributes to build a contract mapping the type to the JSON.
                        var property = type.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                        if (property == null || !property.CanWrite || property.GetIndexParameters().Length > 0 || Attribute.IsDefined(property, typeof(IgnoreDataMemberAttribute)))
                            continue;
                        // Deserialize the value
                        using (var subReader = reader.ReadSubtree())
                        {
                            subReader.MoveToContent();
                            if (typeof(Stream).IsAssignableFrom(property.PropertyType))
                            {
                                var streamValue = CreateTemporaryStream();
                                byte[] buffer = new byte[BufferSize];
                                int readBytes = 0;
                                while ((readBytes = subReader.ReadElementContentAsBase64(buffer, 0, buffer.Length)) > 0)
                                    streamValue.Write(buffer, 0, readBytes);
                                if (streamValue.CanSeek)
                                    streamValue.Position = 0;
                                property.SetValue(model, streamValue);
                            }
                            else
                            {
                                var settings = new DataContractJsonSerializerSettings
                                {
                                    RootName = name,
                                    // Modify other settings as required e.g. DateTimeFormat.
                                };
                                var serializer = new DataContractJsonSerializer(property.PropertyType, settings);
                                var value = serializer.ReadObject(subReader);
                                if (value != null)
                                    property.SetValue(model, value);
                            }
                        }
                        Debug.Assert(reader.NodeType == XmlNodeType.EndElement);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }
        }

        return model;
    }
}
