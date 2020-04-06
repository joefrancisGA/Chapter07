using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class OperatingContexts
    {
        public OperatingContexts()
        {
            AssociateOperatingContexts = new HashSet<AssociateOperatingContexts>();
            OperatingContextCustomers = new HashSet<OperatingContextCustomers>();
        }

        public int Id { get; set; }
        public int OperatingContextTypeId { get; set; }
        public int FacilityId { get; set; }
        public int StatusCodeId { get; set; }
        public int? ThirdPartySupplierId { get; set; }
        public int? LegacyId { get; set; }
        public int? ProviderTypeId { get; set; }
        public int? ActingBatypeId { get; set; }
        public int? CertificationId { get; set; }
        public int? RoleId { get; set; }
        public bool IsDeactivating { get; set; }
        public DateTime StartDate { get; set; }
        public int? PrimaryEmailId { get; set; }
        public int? PrimaryPhoneId { get; set; }
        public int? PrimaryAddressId { get; set; }

        public virtual AssociateTypes ActingBatype { get; set; }
        public virtual Certifications Certification { get; set; }
        public virtual OperatingContextTypes OperatingContextType { get; set; }
        public virtual Addresses PrimaryAddress { get; set; }
        public virtual Emails PrimaryEmail { get; set; }
        public virtual Phones PrimaryPhone { get; set; }
        public virtual ProviderTypes ProviderType { get; set; }
        public virtual Roles Role { get; set; }
        public virtual StatusCodes StatusCode { get; set; }
        public virtual Associates ThirdPartySupplier { get; set; }
        public virtual ICollection<AssociateOperatingContexts> AssociateOperatingContexts { get; set; }
        public virtual ICollection<OperatingContextCustomers> OperatingContextCustomers { get; set; }
    }
}
