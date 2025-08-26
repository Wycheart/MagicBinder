namespace MagicBinder.Domain.Entities;

public class ImageUri : BaseAuditableEntity
{
    public string Small { get; set; } = string.Empty;
    public string Normal { get; set; } = string.Empty;
    public string Large { get; set; } = string.Empty;
    public string Png { get; set; } = string.Empty;
    public string ArtCrop { get; set; } = string.Empty;
    public string BorderCrop { get; set; } = string.Empty;
}
