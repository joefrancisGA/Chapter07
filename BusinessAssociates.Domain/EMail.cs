using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class EMail
    {
        public DatabaseId Id { get; set; }

        public DatabaseId UserId { get; set; }
        public EMailAddress EMailAddress { get; set; }
        public bool IsPrimary { get; set; }
    }
}