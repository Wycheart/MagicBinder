using MagicBinder.Application.Common.Interfaces;

namespace MagicBinder.Application.Collections.Commands.DeleteCollection;
public record DeleteCollectionCommand(int Id) : IRequest;

public class DeleteCollectionCommandHandler : IRequestHandler<DeleteCollectionCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCollectionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteCollectionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Collections
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Collections.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
