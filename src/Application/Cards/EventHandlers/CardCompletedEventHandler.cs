using MagicBinder.Domain.Events;
using Microsoft.Extensions.Logging;

namespace MagicBinder.Application.Cards.EventHandlers;
public class CardCompletedEventHandler : INotificationHandler<CardCompletedEvent>
{
    private readonly ILogger<CardCompletedEventHandler> _logger;

    public CardCompletedEventHandler(ILogger<CardCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CardCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("MagicBinder Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
