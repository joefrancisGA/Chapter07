using System;
using BusinessAssociates.Domain.Enums;

namespace BusinessAssociates.Domain
{
    public abstract class OperatingContext
    {
        public int Id { get; set; }
        public OperatingContextType OperatingContextType { get; set; }
        public int FacilityId { get; set; }
        public int ThirdPartySupplierId { get; set; }
        public int LegacyId { get; set; }
        public ProviderType ProviderType { get; set; }
        public AssociateType ActingBATypeID { get; set; }
        public Certification Certification { get; set; }

        // TO DO:  Do we really have a "set" of roles for the operating context?
        public Role Role { get; set; }
        public Status Status { get; set; }

        public bool IsDeactivating { get; set; }
        public DateTime StartDate { get; set; }
        public EMail PrimaryEmail { get; set; }
        public Phone PrimaryPhone { get; set; }
        public Address PrimaryAddress { get; set; }
    }
}