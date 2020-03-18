namespace BusinessAssociates.Domain
{
    public class UserContactDisplayRules
    {
        public int Id { get; set; }

        public bool IsInternal { get; set; }
        public bool IDMSAccountExists { get; set; }
        public bool IDMSAccountActive { get; set; }
        public bool EGMSConfigured { get; set; }
        public bool IsActive { get; set; }
    }
}