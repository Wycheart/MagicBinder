namespace MagicBinder.Domain.Entities;

public class Collection : BaseAuditableEntity
{
    public string? Title { get; set; }

    public IList<Card> Cards { get; set; } = new List<Card>();
}
