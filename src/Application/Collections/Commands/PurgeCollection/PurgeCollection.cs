using MagicBinder.Application.Common.Interfaces;
using MagicBinder.Application.Common.Security;
using MagicBinder.Domain.Constants;

namespace MagicBinder.Application.Collections.Commands.PurgeCollections;
[Authorize(Roles = Roles.Administrator)]
[Authorize(Policy = Policies.CanPurge)]
public record PurgeCollectionsCommand : IRequest;

public class PurgeCollectionsCommandHandler : IRequestHandler<PurgeCollectionsCommand>
{
    private readonly IApplicationDbContext _context;

    public PurgeCollectionsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(PurgeCollectionsCommand request, CancellationToken cancellationToken)
    {
        _context.Collections.RemoveRange(_context.Collections);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
