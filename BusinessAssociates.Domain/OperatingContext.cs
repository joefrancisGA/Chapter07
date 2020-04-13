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

        public OperatingContext(Action<object> applier) : base(applier)
        {
            Initialize();
        }

        private void Initialize()
        {
            EMails = new HashSet<EMail>();
            Phones = new HashSet<Phone>();
            Addresses = new HashSet<Address>();
            Roles = new HashSet<Role>();
            AssociateOperatingContexts = new HashSet<AssociateOperatingContext>();
            OperatingContextCustomers = new HashSet<OperatingContextCustomer>();
            OperatingContexts = new HashSet<OperatingContext>();
        }

        public OperatingContext(OperatingContextTypeLookup operatingContextType,
            DatabaseId facilityId, DatabaseId thirdPartySupplierId, ActingAssociateTypeLookup actingBATypeId, 
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
        public int ThirdPartySupplierId { get; set; }

        // TO DO:  Not sure what to do with the type for LegacyId
        public int LegacyId { get; set; }

        public ProviderTypeLookup ProviderType { get; set; }
        public int ProviderTypeId { get; set; }

        public ActingAssociateTypeLookup ActingBAType { get; set; }
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


        public HashSet<EMail> EMails { get; set; }
        public HashSet<Phone> Phones { get; set; }
        public HashSet<Address> Addresses { get; set; }
        public HashSet<Role> Roles { get; set; }
        public HashSet<AssociateOperatingContext> AssociateOperatingContexts { get; set; }
        public HashSet<OperatingContextCustomer> OperatingContextCustomers { get; set; }
        public HashSet<OperatingContext> OperatingContexts { get; set; }


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

