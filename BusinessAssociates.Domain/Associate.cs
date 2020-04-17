using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.Exceptions;
using EGMS.BusinessAssociates.Domain.Messages;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Associate : AggregateRoot<int>
    {
        public Associate()
        {
            Initialize();
        }

        //public Associate(int id, string longName, string shortName, bool isParent, bool isInternal, bool isDeactivating,
        //    AssociateTypeLookup associateType, StatusCodeLookup statusCode) : this()
        //{
        //    Initialize();

        //    Events.AssociateCreated associateCreated = new Events.AssociateCreated
        //    {
        //        Id = id,
        //        LongName = longName,
        //        ShortName = shortName,
        //        IsParent = isParent,
        //        AssociateType = associateType.AssociateTypeId,
        //        StatusCode = statusCode
        //    };

        //    Id = id;
        //    DUNSNumber = DUNSNumber.Create(id);
        //    LongName = LongName.Create(longName);
        //    ShortName = ShortName.Create(shortName);
        //    IsParent = isParent;
        //    AssociateType = associateType;
        //    StatusCode = statusCode;

        //    Apply(associateCreated);
        //}

        private void Initialize()
        {
            OperatingContexts = new HashSet<OperatingContext>();
            AgentUsers = new HashSet<AgentUser>();
            AssociateCustomers = new HashSet<AssociateCustomer>();
            AssociateOperatingContexts = new HashSet<AssociateOperatingContext>();
            AssociateUsers = new HashSet<AssociateUser>();
            Customers = new HashSet<Customer>();
            PredecessorBusinessAssociates = new HashSet<Associate>();
            UserOperatingContexts = new HashSet<UserOperatingContext>();
        }

        public static Associate Create(int associateId, int dunsNumber, string longName, string shortName, bool isParent, bool isInternal,
            bool isDeactivating, AssociateTypeLookup associateType, StatusCodeLookup statusCode)
        {
            return new Associate
            {
                Id = associateId,
                DUNSNumber = DUNSNumber.Create(dunsNumber),
                LongName = LongName.Create(longName),
                ShortName = ShortName.Create(shortName),
                IsParent = isParent,
                IsInternal = isInternal,
                IsDeactivating = isDeactivating,
                AssociateType = associateType,
                AssociateTypeId = associateType.AssociateTypeId,
                StatusCode = statusCode,
                StatusCodeId = statusCode.StatusCodeId
            };
        }

        public DUNSNumber DUNSNumber { get; set; }
        public LongName LongName { get; set; }
        public ShortName ShortName { get; set; }

        public AssociateTypeLookup AssociateType { get; set; }
        public int AssociateTypeId { get; set; }

        public StatusCodeLookup StatusCode { get; set; }
        public int StatusCodeId { get; set; }

        public bool IsInternal { get; set; }
        public bool IsDeactivating { get; set; }
        public bool IsParent { get; set; }


        public HashSet<AgentUser> AgentUsers { get; set; }
        public HashSet<AssociateCustomer> AssociateCustomers { get; set; }
        public HashSet<AssociateOperatingContext> AssociateOperatingContexts { get; set; }
        public HashSet<AssociateUser> AssociateUsers { get; set; }
        public HashSet<Customer> Customers { get; set; }

        // TO DO:  This is for third-party suppliers only.  We may need to consolidate this into 
        //   AssociateOperatingContexts
        public HashSet<OperatingContext> OperatingContexts { get; set;}
        public HashSet<Associate> PredecessorBusinessAssociates { get; set; }
        public HashSet<UserOperatingContext> UserOperatingContexts { get; set; }

        public void UpdateDUNSNumber(DUNSNumber dunsNumber) => Apply(new Events.AssociateDUNSNumberUpdated
        {
            DUNSNumber = dunsNumber
        });

        public void UpdateAssociateType(AssociateTypeLookup associateType) => Apply(new Events.AssociateTypeUpdated
        {
            AssociateType = associateType.AssociateTypeId
        });

        public void UpdateLongName(LongName longName) => Apply(new Events.AssociateLongNameUpdated
        {
            LongName = longName.Value
        });

        public void UpdateIsParent(bool isParent) => Apply(new Events.AssociateIsParentUpdated
        {
            IsParent = isParent
        });

        public void UpdateStatus(StatusCodeLookup status) => Apply(new Events.AssociateStatusUpdated
        {
            Status = status.StatusCodeId
        });

        public void UpdateShortName(ShortName shortName) => Apply(new Events.AssociateShortNameUpdated
        {
            ShortName = shortName.Value
        });

        //public void AddOperatingContext(AssociateId associateId, OperatingContextType operatingContextType, DatabaseId facilityId, 
        //    DatabaseId thirdPartySupplierId, AssociateType actingBATypeId, NullableDatabaseId certificationId, bool isDeactivating,
        //    int legacyId, DatabaseId primaryAddressId, DatabaseId primaryEmailId, DatabaseId primaryPhoneId, DatabaseId providerTypeId,
        //    DateTime startDate, Status status)
        //{
        //    OperatingContext operatingContext = new OperatingContext(operatingContextType, facilityId, thirdPartySupplierId,
        //        actingBATypeId, certificationId, isDeactivating, legacyId, primaryAddressId, primaryEmailId, primaryPhoneId,
        //        providerTypeId, startDate, status);

        //    if (AssociateOperatingContexts == null)
        //    {
        //        AssociateOperatingContexts = new List<AssociateOperatingContext>();
        //    }

        //    if (OperatingContexts == null)
        //    {
        //        OperatingContexts = new List<OperatingContext>();
        //    }

        //    OperatingContexts.AddAssociate(operatingContext);

            
        //    Apply(new Events.AssociateAddNewOperatingContext
        //    {
        //        AssociateId = associateId,
        //        OperatingContextType = (int)operatingContextType,
        //        FacilityId = facilityId,
        //        ThirdPartySupplierId = thirdPartySupplierId, 
        //        ActingBATypeId = (int)actingBATypeId,
        //        CertificationId = certificationId,
        //        IsDeactivating = isDeactivating, 
        //        LegacyId = legacyId, 
        //        PrimaryAddressId = primaryAddressId, 
        //        PrimaryEmailId = primaryEmailId, 
        //        PrimaryPhoneId  = primaryPhoneId, 
        //        ProviderTypeId = providerTypeId, 
        //        StartDate = startDate, 
        //        StatusCodeId = (int)status
        //    });
        //}

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.AssociateCreated e:
                    Id = new AssociateId(e.Id);
                    break;

                case Events.AssociateDUNSNumberUpdated e:
                    DUNSNumber = DUNSNumber.Create(e.DUNSNumber);
                    break;

                case Events.AssociateIsParentUpdated e:
                    IsParent = e.IsParent;
                    break;

                case Events.AssociateLongNameUpdated e:
                    LongName = LongName.Create(e.LongName);
                    break;

                case Events.AssociateShortNameUpdated e:
                    ShortName = ShortName.Create(e.ShortName);
                    break;

                case Events.AssociateStatusUpdated e:
                    StatusCode = StatusCodeLookup.StatusCodes[e.Status];
                    break;

                case Events.AssociateTypeUpdated e:
                    AssociateType = AssociateTypeLookup.AssociateTypes[e.AssociateType];
                    break;

                case Events.AssociateAddNewOperatingContext e:
                    OperatingContext operatingContext = new OperatingContext(Apply);
                    ApplyToEntity(operatingContext, e);
                    //OperatingContexts.AddAssociate(operatingContext);
                    break;

                default:
                    throw new Exception("Unknown event type " + @event);
            }
        }

        protected override void EnsureValidState()
        {
            var valid = true;
                //Id != null;// &&
                           //State switch
                           //{
                           //    InternalAssociateState.PendingReview =>
                           //    Text != null,
                           //    InternalAssociateState.Active =>
                           //    Text != null,
                           //    _ => true
                           //};

            if (!valid)
                throw new InvalidEntityStateException(this, "Post-checks failed");
        }


        public void AddOperatingContext(OperatingContext operatingContext) =>
            Apply(new Events.AssociateAddNewOperatingContext
                {
                    OperatingContextType = operatingContext.OperatingContextType.OperatingContextTypeId,
                    FacilityId = operatingContext.FacilityId,
                    ThirdPartySupplierId = operatingContext.ThirdPartySupplierId,
                    LegacyId = operatingContext.LegacyId,
                    ActingBATypeId = operatingContext.ActingBAType.ActingAssociateTypeId,
                    CertificationId = operatingContext.CertificationId,
                    StatusCodeId = operatingContext.Status.StatusCodeId,
                    IsDeactivating = operatingContext.IsDeactivating,
                    StartDate = operatingContext.StartDate,
                    PrimaryEmailId = operatingContext.PrimaryEmailId,
                    PrimaryPhoneId = operatingContext.PrimaryPhoneId,
                    PrimaryAddressId = operatingContext.PrimaryAddressId
                }
            );

        public static Associate Create(int associateId, ShortName shortName, LongName longName, AssociateTypeLookup associateType,
            bool isParent, bool isInternal, StatusCodeLookup statusCode)
        {
            var associate = new Associate();

            associate.Apply(
                new Events.AssociateCreated
                {
                    Id = associateId,
                    ShortName = shortName,
                    LongName = longName,
                    AssociateType = associateType.AssociateTypeId,
                    IsParent = isParent,
                    IsInternal = isInternal, 
                    StatusCode = statusCode
                }
            );

            return associate;
        }
    }
}