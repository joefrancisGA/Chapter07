using EGMS.BusinessAssociates.Domain.ValueObjects;

namespace EGMS.BusinessAssociates.Domain
{
    public class UserContactDisplayRules
    {
        public DatabaseId Id { get; set; }

        public bool IsInternal { get; set; }
        public bool IDMSAccountExists { get; set; }
        public bool IDMSAccountActive { get; set; }
        public bool EGMSConfigured { get; set; }
        public bool IsActive { get; set; }
    }
}