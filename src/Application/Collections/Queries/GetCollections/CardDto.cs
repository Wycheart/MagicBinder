using MagicBinder.Domain.Entities;

namespace MagicBinder.Application.Collections.Queries.GetCollections;
public class CardDto
{
    public int Id { get; init; }

    public string? Name { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TodoItem, CardDto>();
        }
    }
}
