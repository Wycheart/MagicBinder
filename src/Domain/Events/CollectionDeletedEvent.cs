namespace MagicBinder.Domain.Events;

public class CollectionDeletedEvent : BaseEvent
{
    public CollectionDeletedEvent(Collection collection)
    {
        Collection = collection;
    }

    public Collection Collection { get; }
}
