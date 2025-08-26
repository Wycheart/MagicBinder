using MagicBinder.Application.Common.Interfaces;
using MagicBinder.Domain.Events;

namespace MagicBinder.Application.Cards.Commands.DeleteCard;
public record DeleteCardCommand(int Id) : IRequest;

public class DeleteCardCommandHandler : IRequestHandler<DeleteCardCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCardCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteCardCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Cards
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Cards.Remove(entity);

        entity.AddDomainEvent(new CardDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
