using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.Messages;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class OperatingContext : Entity<int>
    {
        protected OperatingContext()
        {
            Initialize();
        }

        private void Initialize()
        {
            EMails = new List<EMail>();
            Phones = new List<Phone>();
            Addresses = new List<Address>();
            Roles = new List<Role>();
            AssociateOperatingContexts = new List<AssociateOperatingContext>();
        }

        public OperatingContext(Action<object> applier) : base(applier)
        {
            Initialize();
        }

        public OperatingContext(OperatingContextTypeLookup operatingContextType,
            DatabaseId facilityId, DatabaseId thirdPartySupplierId, AssociateTypeLookup actingBATypeId, 
            NullableDatabaseId certificationId, bool isDeactivating, int legacyId, DatabaseId primaryAddressId, 
            DatabaseId primaryEmailId, DatabaseId primaryPhoneId, DatabaseId providerTypeId,
            DateTime startDate, StatusCodeLookup status) : this()
        {
            OperatingContextType = operatingContextType;
            FacilityId = facilityId;
            ThirdPartySupplierId = thirdPartySupplierId;
            ActingBAType = actingBATypeId;
            CertificationId = certificationId;
            LegacyId = legacyId;
            PrimaryAddressId = primaryAddressId;
            PrimaryEmailId = primaryEmailId;
            PrimaryPhoneId = primaryPhoneId;
            ProviderType = ProviderTypeLookup.ProviderTypes[providerTypeId];
            IsDeactivating = isDeactivating;
            StartDate = startDate != default ? startDate : DateTime.Now;
            Status = status;
        }


        public OperatingContextTypeLookup OperatingContextType { get; set; }
        public int OperatingContextTypeId { get; set; }

        public DatabaseId FacilityId { get; set; }

        public Associate ThirdPartySupplier { get; set; }
        public DatabaseId ThirdPartySupplierId { get; set; }

        // TO DO:  Not sure what to do with the type for LegacyId
        public int LegacyId { get; set; }

        public ProviderTypeLookup ProviderType { get; set; }
        public int ProviderTypeId { get; set; }

        public AssociateTypeLookup ActingBAType { get; set; }
        public int ActingBATypeId { get; set; }

        public Certification Certification { get; set; }
        public NullableDatabaseId CertificationId { get; set; }

        public Role Role { get; set; }
        public int RoleId { get; set; }


        public StatusCodeLookup Status { get; set; }
        public int StatusCodeId { get; set; }

        public bool IsDeactivating { get; set; }
        public DateTime StartDate { get; set; }
        public EMail PrimaryEmail { get; set; }
        public Phone PrimaryPhone { get; set; }
        public Address PrimaryAddress { get; set; }

        public int PrimaryEmailId { get; set; }
        public int PrimaryPhoneId { get; set; }
        public int PrimaryAddressId { get; set; }


        public List<EMail> EMails { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Role> Roles { get; set; }
        public List<AssociateOperatingContext> AssociateOperatingContexts { get; set; }
        public List<OperatingContextCustomer> OperatingContextCustomers { get; set; }
        public List<OperatingContext> OperatingContexts { get; set; }


        protected override void When(object @event)
        {
            switch (@event)
            { 
                case Events.AssociateAddNewOperatingContext e:
                    break;

                default:
                    throw new Exception("Unknown event " + @event);
            }
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}

