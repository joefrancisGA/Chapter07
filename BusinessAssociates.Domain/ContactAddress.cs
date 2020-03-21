using EGMS.BusinessAssociates.Domain.ValueObjects;

namespace EGMS.BusinessAssociates.Domain
{
    public class ContactAddress
    {
        public DatabaseId ContactId { get; set; }
        public DatabaseId AddressId { get; set; }
    }
}