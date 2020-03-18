using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class AssociateLifecycleEvent
    {
        public AssociateId AssociateId { get; set; }
        public DatabaseId LifecycleEventId { get; set; }
    }
}