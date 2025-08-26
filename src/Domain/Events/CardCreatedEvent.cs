namespace MagicBinder.Domain.Events;

public class CardCreatedEvent : BaseEvent
{
    public CardCreatedEvent(Card card)
    {
        Card = card;
    }

    public Card Card { get; }
}
