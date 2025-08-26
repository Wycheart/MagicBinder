using MagicBinder.Application.Common.Interfaces;
using MagicBinder.Domain.Entities;

namespace MagicBinder.Application.Collections.Commands.UpdateCollection;
public record UpdateCollectionCommand : IRequest
{
    public required Collection Collection { get; set; }
}

public class UpdateCollectionCommandHandler : IRequestHandler<UpdateCollectionCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCollectionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCollectionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Collections
            .FindAsync(new object[] { request.Collection.Id }, cancellationToken);

        Guard.Against.NotFound(request.Collection.Id, entity);

        entity = request.Collection;

        await _context.SaveChangesAsync(cancellationToken);

    }
}
