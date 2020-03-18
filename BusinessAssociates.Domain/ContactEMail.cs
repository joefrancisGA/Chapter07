using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class ContactEMail
    {
        public DatabaseId ContactId { get; set; }
        public DatabaseId EMail { get; set; }
    }
}