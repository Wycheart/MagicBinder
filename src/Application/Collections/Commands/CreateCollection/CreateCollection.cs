using MagicBinder.Application.Common.Interfaces;
using MagicBinder.Domain.Entities;

namespace MagicBinder.Application.Collections.Commands.CreateCollection;
public record CreateCollectionCommand : IRequest<int>
{
    public required string Title { get; set; }
    public List<int> CardIds { get; set; } = [];
}

public class CreateCollectionCommandHandler : IRequestHandler<CreateCollectionCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCollectionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCollectionCommand request, CancellationToken cancellationToken)
    {
        var result = _context.Cards.Where(x => request.CardIds!.Contains(x.Id)).ToList();
        var entity = new Collection
        {
            Title = request.Title,
            Cards = result
        };

        _context.Collections.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
