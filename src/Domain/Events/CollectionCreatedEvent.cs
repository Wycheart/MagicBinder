namespace MagicBinder.Domain.Events;

public class CollectionCreatedEvent : BaseEvent
{
    public CollectionCreatedEvent(Collection collection)
    {
        Collection = collection;
    }

    public Collection Collection { get; }
}
