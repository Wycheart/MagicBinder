using MagicBinder.Application.Common.Interfaces;

namespace MagicBinder.Application.Cards.Commands.UpdateCard;
public record UpdateCardCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }
}

public class UpdateCardCommandHandler : IRequestHandler<UpdateCardCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCardCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCardCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Cards
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Title!;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
