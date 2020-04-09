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
            //OperatingContexts = new List<OperatingContext>();
            //AssociateOperatingContexts = new List<AssociateOperatingContext>();
        }

        public Associate(int id, string longName, string shortName, bool isParent,
            AssociateTypeLookup associateType, StatusCodeLookup status) : this()
        {
            Events.AssociateCreated associateCreated = new Events.AssociateCreated
            {
                Id = id,
                LongName = longName,
                ShortName = shortName,
                IsParent = isParent,
                AssociateType = associateType.AssociateTypeId,
                Status = status
            };

            Id = id;
            DUNSNumber = DUNSNumber.Create(id);
            LongName = LongName.Create(longName);
            ShortName = ShortName.Create(shortName);
            IsParent = isParent;
            AssociateType = associateType;
            Status = status;

            Apply(associateCreated);
        }

        public static Associate Create(int id, string longName, string shortName, bool isParent,
            AssociateTypeLookup associateType, StatusCodeLookup status)
        {
            Associate associate = new Associate();

            associate.DUNSNumber = DUNSNumber.Create(id);
            associate.LongName = LongName.Create(longName);
            associate.ShortName = ShortName.Create(shortName);
            associate.IsParent = isParent;
            associate.AssociateType = associateType;
            associate.Status = status;

            return associate;
        }

        public DUNSNumber DUNSNumber { get; set; }
        public LongName LongName { get; set; }
        public ShortName ShortName { get; set; }
        public AssociateTypeLookup AssociateType { get; set; }
        public StatusCodeLookup Status { get; set; }

        public bool IsInternal { get; set; }
        public bool IsDeactivating { get; set; }
        public bool IsParent { get; set; }
        public bool IsActive { get; set; }


        public List<AgentUser> AgentUsers { get; set; }
        public List<AssociateCustomer> AssociateCustomers { get; set; }
        public List<AssociateOperatingContext> AssociateOperatingContexts { get; set; }
        public List<AssociateUser> AssociateUsers { get; set; }
        public List<Customer> Customers { get; set; }

        // TO DO:  This is for third-party suppliers only.  We may need to consolidate this into 
        //   AssociateOperatingContexts
        public List<OperatingContext> OperatingContexts { get; set;}
        public List<PredecessorBusinessAssociate> PredecessorAssociates { get; set; }
        public List<UserOperatingContext> UserOperatingContexts { get; set; }

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

        //    OperatingContexts.Add(operatingContext);

            
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
        //        StatusId = (int)status
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
                    Status = StatusCodeLookup.StatusCodes[e.Status];
                    break;

                case Events.AssociateTypeUpdated e:
                    AssociateType = AssociateTypeLookup.AssociateTypes[e.AssociateType];
                    break;

                case Events.AssociateAddNewOperatingContext e:
                    OperatingContext operatingContext = new OperatingContext(Apply);
                    ApplyToEntity(operatingContext, e);
                    //OperatingContexts.Add(operatingContext);
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
                    ActingBATypeId = operatingContext.ActingBAType.AssociateTypeId,
                    CertificationId = operatingContext.CertificationId,
                    StatusId = operatingContext.Status.StatusCodeId,
                    IsDeactivating = operatingContext.IsDeactivating,
                    StartDate = operatingContext.StartDate,
                    PrimaryEmailId = operatingContext.PrimaryEmailId,
                    PrimaryPhoneId = operatingContext.PrimaryPhoneId,
                    PrimaryAddressId = operatingContext.PrimaryAddressId
                }
            );

        public static Associate Create(
            ShortName shortName,
            LongName longName,
            AssociateTypeLookup associateType,
            bool isParent,
            StatusCodeLookup status)
        {
            var associate = new Associate();

            associate.Apply(
                new Events.AssociateCreated
                {
                    ShortName = shortName,
                    LongName = longName,
                    AssociateType = associateType.AssociateTypeId,
                    IsParent = isParent,
                    Status = status
                }
            );

            return associate;
        }
    }
}