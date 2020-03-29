using System;

namespace EGMS.BusinessAssociates.Query.ReadModels
{
    public class OperatingContextRM
    {
        public int Id { get; set; }
        public int OperatingContextType { get; set; }

        public int FacilityId { get; set; }
        public int ThirdPartySupplierId { get; set; }

        public int LegacyId { get; set; }
        public int ProviderType { get; set; }
        public int ActingBAType { get; set; }
        public int? CertificationId { get; set; }

        public int Status { get; set; }

        public bool IsDeactivating { get; set; }
        public DateTime StartDate { get; set; }
        public int PrimaryEmail { get; set; }
        public int PrimaryPhone { get; set; }
        public int PrimaryAddress { get; set; }
    }
}

