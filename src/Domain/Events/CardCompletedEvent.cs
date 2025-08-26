namespace MagicBinder.Domain.Events;

public class CardCompletedEvent : BaseEvent
{
    public CardCompletedEvent(Card card)
    {
        Card = card;
    }

    public Card Card { get; }
}
