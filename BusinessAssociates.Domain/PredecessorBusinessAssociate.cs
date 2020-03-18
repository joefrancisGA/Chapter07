using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class PredecessorBusinessAssociate
    {
        public DatabaseId AssociateId { get; set; }
        public DatabaseId PredecessorBusinessAssociateId { get; set; }
    }
}