using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class AssociateCustomer
    {
        public AssociateId AssociateId { get; set; }
        public DatabaseId CustomerId { get; set; }
    }
}