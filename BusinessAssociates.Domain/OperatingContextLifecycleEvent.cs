using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class OperatingContextLifecycleEvent
    {
        public DatabaseId OperatingContextId { get; set; }
        public DatabaseId LifecycleEventId { get; set; }
    }
}