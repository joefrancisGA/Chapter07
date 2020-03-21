using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;

namespace EGMS.BusinessAssociates.Domain
{
    public class Phone
    {
        public DatabaseId Id { get; set; }

        public DatabaseId UserId { get; set; }
        public PhoneType PhoneType { get; set; }
        public Extension Extension { get; set; }
        public bool IsPrimary { get; set; }
    }
}