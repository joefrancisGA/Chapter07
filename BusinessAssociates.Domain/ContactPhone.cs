using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class ContactPhone
    {
        public DatabaseId ContactId { get; set; }
        public DatabaseId PhoneId { get; set; }
    }
}