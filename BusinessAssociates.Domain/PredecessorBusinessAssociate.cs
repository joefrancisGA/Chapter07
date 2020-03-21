using EGMS.BusinessAssociates.Domain.ValueObjects;

namespace EGMS.BusinessAssociates.Domain
{
    public class PredecessorBusinessAssociate
    {
        public DatabaseId AssociateId { get; set; }
        public DatabaseId PredecessorBusinessAssociateId { get; set; }
    }
}