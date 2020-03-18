﻿using System.Collections.Generic;
using BusinessAssociates.Domain.Enums;
using BusinessAssociates.Domain.ValueObjects;
using BusinessAssociates.Framework;

namespace BusinessAssociates.Domain
{
    public class InternalAssociate : AggregateRoot<AssociateId>
    {
        // Properties in common with external business associates
        public Status Status { get; set; }
        public DUNSNumber DUNSNumber { get; set; }
        public LongName LongName { get; set; }
        public ShortName ShortName { get; set; }

        // Properties unique to Internal Business Associate
        public AssociateType InternalAssociateType { get; set; }


        // Collections
        public List<OperatingContext> OperatingContexts { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        private List<AgentRelationship> AssetManagerRelationships { get; set; }

        // It is questionable whether we need this property
        // If the InternalBusinessAssociateType is Parent or OperatingCompany, 
        //   then we know it is a parent.
        public bool IsParent { get; set; }

        public InternalAssociate() { }

        public InternalAssociate(InternalAssociateId id)
        {
            Apply(new Events.InternalAssociateCreated
            {
                Id = id.Value
            });
        }

        // TO DO:  Skip the ID before creating the Internal Associate
        public InternalAssociate(AssociateId id, string longName, string shortName, bool isParent, 
            AssociateType internalAssociateType, Status status)
        {
            Events.InternalAssociateCreated internalAssociateCreated = new Events.InternalAssociateCreated
            {
                Id = id.Value,
                LongName = longName,
                ShortName = shortName,
                IsParent = isParent,
                InternalAssociateType = internalAssociateType,
                Status = status
            };

            Id = id;
            DUNSNumber = DUNSNumber.Create(id.Value);
            LongName = LongName.Create(longName);
            ShortName = ShortName.Create(shortName);
            IsParent = isParent;
            InternalAssociateType = internalAssociateType;
            Status = status;

            Apply(internalAssociateCreated);
        }


        public void UpdateDUNSNumber(DUNSNumber dunsNumber) => Apply(new Events.InternalAssociateDUNSNumberUpdated
            {
                Id = Id.Value,
                DUNSNumber = dunsNumber
            }
        );

        public void UpdateInternalAssociateType(AssociateType internalAssociateType) => Apply(new Events.InternalAssociateTypeUpdated
            {
                Id = Id.Value,
                InternalAssociateType = (int)internalAssociateType
            }
        );

        public void UpdateLongName(LongName longName) => Apply(new Events.InternalAssociateLongNameUpdated
            {
                Id = Id.Value,
                LongName = longName.Value
            }
        );

        public void UpdateIsParent(bool isParent) => Apply(new Events.InternalAssociateIsParentUpdated
            {
                Id = Id.Value,
                IsParent = isParent
            }
        );

        public void UpdateStatus(Status status) => Apply(new Events.InternalAssociateStatusUpdated
            {
                Id = Id.Value,
                Status = (int)status
            }
        );

        public void UpdateShortName(ShortName shortName) => Apply(new Events.InternalAssociateShortNameUpdated
            {
                Id = Id.Value,
                ShortName = shortName.Value
            }
        );

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.InternalAssociateCreated e:
                    Id = new AssociateId(e.Id);
                    break;

                case Events.InternalAssociateDUNSNumberUpdated e:
                    DUNSNumber = DUNSNumber.Create(e.DUNSNumber);
                    break;

                case Events.InternalAssociateIsParentUpdated e:
                    IsParent = e.IsParent;
                    break;

                case Events.InternalAssociateLongNameUpdated e:
                    LongName = LongName.Create(e.LongName);
                    break;

                case Events.InternalAssociateShortNameUpdated e:
                    ShortName = ShortName.Create(e.ShortName);
                    break;

                case Events.InternalAssociateStatusUpdated e:
                    Status = (Status)e.Status;
                    break;

                case Events.InternalAssociateTypeUpdated e:
                    InternalAssociateType = (AssociateType) e.InternalAssociateType;
                    break;
            }
        }

        protected override void EnsureValidState()
        {
            var valid =
                Id != null;// &&
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
    }
}