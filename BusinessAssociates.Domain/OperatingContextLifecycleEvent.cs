using EGMS.BusinessAssociates.Domain.ValueObjects;

namespace EGMS.BusinessAssociates.Domain
{
    public class OperatingContextLifecycleEvent
    {
        public DatabaseId OperatingContextId { get; set; }
        public DatabaseId LifecycleEventId { get; set; }
    }
}