using System.Security.Cryptography.X509Certificates;
using HelpfulThings.Connect.Scryfall.Clients;
using MagicBinder.Application.Common.Interfaces;
using MagicBinder.Domain.Entities;
using MagicBinder.Domain.Enums;
using MagicBinder.Domain.Events;
using Microsoft.Extensions.DependencyInjection.Common.Response;
using Microsoft.Extensions.DependencyInjection.Helper;
using Newtonsoft.Json;

namespace MagicBinder.Application.Cards.Commands.BulkImportCard;

public record BulkImportCardCommand : IRequest<BulkImportCardResponse>
{
    public required string FileLocation { get; set; }
}

public class BulkImportCardResponse : Response
{
    public required int CardsImported { get; set; }
}

public class BulkImportCardCommandHandler : IRequestHandler<BulkImportCardCommand, BulkImportCardResponse>
{
    private readonly IApplicationDbContext _context;

    public BulkImportCardCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<BulkImportCardResponse> Handle(BulkImportCardCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.FileLocation) || !File.Exists(request.FileLocation))
        {
            return new() { CardsImported = 0, Error = "Invalid bulk file location"};
        }

        List<Card> models = new();
        using (var sr = new StreamReader(request.FileLocation))
        using (var reader = new JsonTextReader(sr))
        {
            var serializer = new JsonSerializer();

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.StartArray)
                    break;
            }

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.StartObject && reader is not null)
                {
                    var model = serializer.Deserialize<Card>(reader);
                    
                    if (model is not null)
                    {
                        model.AddDomainEvent(new CardCreatedEvent(model));
                        models.Add(model);
                    }
                }
                else if (reader!.TokenType == JsonToken.EndArray)
                    break;
            }
        }

        const int batchSize = 1000;
        for (int i = 0; i < models.Count; i += batchSize)
        {
            var batch = models.Skip(i).Take(batchSize).ToList();
            _context.Cards.AddRange(batch);
            await _context.SaveChangesAsync(cancellationToken);

            Console.WriteLine("Nieuwe Batch");
        }

        return new(){ CardsImported = models.Count() };
    }
}
