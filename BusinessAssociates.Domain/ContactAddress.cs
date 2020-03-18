using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class ContactAddress
    {
        public DatabaseId ContactId { get; set; }
        public DatabaseId AddressId { get; set; }
    }
}