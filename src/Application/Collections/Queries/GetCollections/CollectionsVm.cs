namespace MagicBinder.Application.Collections.Queries.GetCollections;
public class CollectionsVm
{
    public IReadOnlyCollection<CollectionDto> Collection { get; init; } = Array.Empty<CollectionDto>();
}
