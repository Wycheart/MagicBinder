namespace MagicBinder.Domain.Events;

public class CardDeletedEvent : BaseEvent
{
    public CardDeletedEvent(Card card)
    {
        Card = card;
    }

    public Card Card { get; }
}
