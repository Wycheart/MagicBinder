using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MagicBinder.Domain.Entities;

public class Card : BaseAuditableEntity
{
    [JsonProperty("id")] 
    public Guid ScryFallId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Lang { get; set; }
    public string? Uri { get; set; }
    public string? Scryfall_uri { get; set; }
    public Guid? OracleId { get; set; }
    public IList<int?> MultiverseIds { get; set; } = new List<int?>();
    public int? MtgoId { get; set; }
    public int? ArenaId { get; set; }
    public int? MtgoFoilId { get; set; }
    public string? ScryfallUri { get; set; } = string.Empty;
    public string? PrintsSearchUri { get; set; } = string.Empty;
    public string? RulingsUri { get; set; } = string.Empty;
    public Layouts? Layout { get; set; }
    public double? Cmc { get; set; }
    public string? TypeLine { get; set; } = string.Empty;
    public string? OracleText { get; set; } = string.Empty;
    public string ManaCost { get; set; } = string.Empty;
    public string? Power { get; set; } = string.Empty;
    public string? Toughness { get; set; } = string.Empty;
    public string? Loyalty { get; set; } = string.Empty;
    public string LifeModifier { get; set; } = string.Empty;
    public string? HandModifier { get; set; } = string.Empty;
    public IList<Colors?> Colors { get; set; } = new List<Colors?>();
    public IList<Colors?> ColorIndicator { get; set; } = new List<Colors?>();
    public IList<Colors?> ColorIdentity { get; set; } = new List<Colors?>();
    public bool? Reserved { get; set; }
    public string? Set { get; set; } = string.Empty;
    public string? SetName { get; set; } = string.Empty;
    public string? CollectorNumber { get; set; } = string.Empty;
    public string? SetSearchUri { get; set; } = string.Empty;
    public string? ScryfallSetUri { get; set; } = string.Empty;
    public ImageUri? ImageUris { get; set; } = new ImageUri(); 
    public bool? HighResImage { get; set; }
    public bool? Reprint { get; set; }
    public bool? Digital { get; set; }
    public Rarity? Rarity { get; set; }
    public string? FlavorText { get; set; } = string.Empty;
    public string? Artist { get; set; } = string.Empty;
    public System.Guid? IllustrationId { get; set; }
    public string? Frame { get; set; } = string.Empty;
    public bool? FullArt { get; set; }
    public string? Watermark { get; set; } = string.Empty;
    public BorderColors? BorderColor { get; set; }
    public int? StorySpotlightNumber { get; set; }
    public string? StorySpotlightUri { get; set; } = string.Empty;
    public bool? Timeshifted { get; set; }
    public bool? Colorshifted { get; set; }
    public bool? Futureshifted { get; set; }
    
    public IList<Collection>? Collections { get; set; } = new List<Collection>();
}
