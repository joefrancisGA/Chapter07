using EGMS.BusinessAssociates.Domain.ValueObjects;

namespace EGMS.BusinessAssociates.Domain
{
    public class OperatingContextCustomer
    {
        public DatabaseId OperatingContextId { get; set; }
        public DatabaseId CustomerId { get; set; }
    }
}