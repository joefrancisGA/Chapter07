using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class OperatingContextCustomer
    {
        public DatabaseId OperatingContextId { get; set; }
        public DatabaseId CustomerId { get; set; }
    }
}