using MagicBinder.Application.Common.Interfaces;
using MagicBinder.Domain.Enums;

namespace MagicBinder.Application.Cards.Commands.UpdateCardDetail;
public record UpdateCardDetailCommand : IRequest
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public PriorityLevel Priority { get; init; }

    public string? Note { get; init; }
}

public class UpdateCardDetailCommandHandler : IRequestHandler<UpdateCardDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCardDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCardDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Cards
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        //entity.ListId = request.ListId;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
