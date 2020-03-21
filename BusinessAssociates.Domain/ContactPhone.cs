using EGMS.BusinessAssociates.Domain.ValueObjects;

namespace EGMS.BusinessAssociates.Domain
{
    public class ContactPhone
    {
        public DatabaseId ContactId { get; set; }
        public DatabaseId PhoneId { get; set; }
    }
}