using EGMS.BusinessAssociates.Domain.ValueObjects;

namespace EGMS.BusinessAssociates.Domain
{
    public class CustomerOperatingContext
    {
        public DatabaseId CustomerId { get; set; }
        public DatabaseId OperatingContextId { get; set; }
    }
}