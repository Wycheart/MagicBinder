using MagicBinder.Domain.Events;
using Microsoft.Extensions.Logging;

namespace MagicBinder.Application.Cards.EventHandlers;
public class CardCreatedEventHandler : INotificationHandler<CardCreatedEvent>
{
    private readonly ILogger<CardCreatedEventHandler> _logger;

    public CardCreatedEventHandler(ILogger<CardCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CardCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("MagicBinder Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
