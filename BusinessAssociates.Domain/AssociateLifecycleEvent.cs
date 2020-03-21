using EGMS.BusinessAssociates.Domain.ValueObjects;

namespace EGMS.BusinessAssociates.Domain
{
    public class AssociateLifecycleEvent
    {
        public AssociateId AssociateId { get; set; }
        public DatabaseId LifecycleEventId { get; set; }
    }
}