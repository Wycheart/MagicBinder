using MagicBinder.Domain.Entities;

namespace MagicBinder.Application.Collections.Queries.GetCollections;
public class CollectionDto
{
    public CollectionDto()
    {
        Collection = Array.Empty<CardDto>();
    }

    public int Id { get; init; }

    public string? Title { get; init; }

    public string? Colour { get; init; }

    public IReadOnlyCollection<CardDto> Collection { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Collection, CollectionDto>();
        }
    }
}
