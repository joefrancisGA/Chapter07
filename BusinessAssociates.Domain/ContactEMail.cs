using EGMS.BusinessAssociates.Domain.ValueObjects;

namespace EGMS.BusinessAssociates.Domain
{
    public class ContactEMail
    {
        public DatabaseId ContactId { get; set; }
        public DatabaseId EMail { get; set; }
    }
}