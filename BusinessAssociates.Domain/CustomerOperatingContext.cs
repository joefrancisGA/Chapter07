using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class CustomerOperatingContext
    {
        public DatabaseId CustomerId { get; set; }
        public DatabaseId OperatingContextId { get; set; }
    }
}