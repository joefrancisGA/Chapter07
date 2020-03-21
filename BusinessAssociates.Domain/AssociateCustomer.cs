using EGMS.BusinessAssociates.Domain.ValueObjects;

namespace EGMS.BusinessAssociates.Domain
{
    public class AssociateCustomer
    {
        public AssociateId AssociateId { get; set; }
        public DatabaseId CustomerId { get; set; }
    }
}