using System;
using BusinessAssociates.Domain.Enums;

namespace BusinessAssociates.Domain
{
    public class UserContactDisplayRules
    {
        public int Id { get; set; }

        public bool IsInternal { get; set; }
        public bool IDMSAccountExists { get; set; }
        public IDMSAccountStatus IDMSAccountStatus { get; set; }
        public bool EGMSConfigured { get; set; }
        public EGMSAccountStatus EGMSAccountStatus { get; set; }
    }
}