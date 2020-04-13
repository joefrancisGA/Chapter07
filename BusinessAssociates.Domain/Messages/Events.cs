using System;
using EGMS.BusinessAssociates.Domain.Enums;

namespace EGMS.BusinessAssociates.Domain.Messages
{
    public static class Events
    {
        public class AssociateCreated
        {
            public int Id { get; set; }

            public string LongName { get; set; }
            public string ShortName { get; set; }
            public bool IsParent { get; set; }
            public bool IsInternal { get; set; }
            public int AssociateType { get; set; }
            public StatusCodeLookup StatusCode { get; set; }
        }

        public class AssociateDUNSNumberUpdated
        {
            public int Id { get; set; }
            public int DUNSNumber { get; set; }
        }

        public class AssociateTypeUpdated
        {
            public int Id { get; set; }
            public int AssociateType { get; set; }
        }

        public class AssociateLongNameUpdated
        {
            public int Id { get; set; }
            public string LongName { get; set; }
        }

        public class AssociateIsParentUpdated
        {
            public int Id { get; set; }
            public bool IsParent { get; set; }
        }

        public class AssociateStatusUpdated
        {
            public int Id { get; set; }
            public int Status { get; set; }
        }

        public class AssociateShortNameUpdated
        {
            public int Id { get; set; }
            public string ShortName { get; set; }
        }

        public class AssociateAddNewOperatingContext
        {
            public int AssociateId { get; set; }
            public int OperatingContextType { get; set; }
            public int FacilityId { get; set; }
            public int ThirdPartySupplierId { get; set; }

            // TO DO:  Not sure what to do with the type for LegacyId
            public int LegacyId { get; set; }
            public int ProviderTypeId { get; set; }
            public int ActingBATypeId { get; set; }
            public int? CertificationId { get; set; }
            public int StatusCodeId { get; set; }
            public bool IsDeactivating { get; set; }
            public DateTime StartDate { get; set; }
            public int PrimaryEmailId { get; set; }
            public int PrimaryPhoneId { get; set; }
            public int PrimaryAddressId { get; set; }
        }
    }
}