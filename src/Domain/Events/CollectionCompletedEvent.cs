namespace MagicBinder.Domain.Events;

public class CollectionCompletedEvent : BaseEvent
{
    public CollectionCompletedEvent(Collection collection)
    {
        Collection = collection;
    }

    public Collection Collection { get; }
}
