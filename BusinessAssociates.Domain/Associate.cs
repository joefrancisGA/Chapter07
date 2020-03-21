using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.Exceptions;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Associate : AggregateRoot<AssociateId>
    {
        public DUNSNumber DUNSNumber { get; set; }
        public LongName LongName { get; set; }
        public ShortName ShortName { get; set; }
        public AssociateType AssociateType { get; set; }
        public Status Status { get; set; }

        public bool IsInternal { get; set; }
        public bool IsDeactivating { get; set; }
        public bool IsParent { get; set; }
        public bool IsActive { get; set; }

        public Associate(AssociateId id)
        {
            Apply(new Events.Events.AssociateCreated
            {
                Id = id.Value
            });
        }

        // TO DO:  Skip the ID before creating the Associate
        public Associate(AssociateId id, string longName, string shortName, bool isParent,
            AssociateType associateType, Status status)
        {
            Events.Events.AssociateCreated associateCreated = new Events.Events.AssociateCreated
            {
                Id = id.Value,
                LongName = longName,
                ShortName = shortName,
                IsParent = isParent,
                AssociateType = associateType,
                Status = status
            };

            Id = id;
            DUNSNumber = DUNSNumber.Create(id.Value);
            LongName = LongName.Create(longName);
            ShortName = ShortName.Create(shortName);
            IsParent = isParent;
            AssociateType = associateType;
            Status = status;

            Apply(associateCreated);
        }


        public void UpdateDUNSNumber(DUNSNumber dunsNumber) => Apply(new Events.Events.AssociateDUNSNumberUpdated
        {
            Id = Id.Value,
            DUNSNumber = dunsNumber
        });

        public void UpdateAssociateType(AssociateType associateType) => Apply(new Events.Events.AssociateTypeUpdated
        {
            Id = Id.Value,
            AssociateType = (int)associateType

        });

        public void UpdateLongName(LongName longName) => Apply(new Events.Events.AssociateLongNameUpdated
        {
            Id = Id.Value,
            LongName = longName.Value
        }
        );

        public void UpdateIsParent(bool isParent) => Apply(new Events.Events.AssociateIsParentUpdated
        {
            Id = Id.Value,
            IsParent = isParent
        }
        );

        public void UpdateStatus(Status status) => Apply(new Events.Events.AssociateStatusUpdated
        {
            Id = Id.Value,
            Status = (int)status
        }
        );

        public void UpdateShortName(ShortName shortName) => Apply(new Events.Events.AssociateShortNameUpdated
        {
            Id = Id.Value,
            ShortName = shortName.Value
        }
        );

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.Events.AssociateCreated e:
                    Id = new AssociateId(e.Id);
                    break;

                case Events.Events.AssociateDUNSNumberUpdated e:
                    DUNSNumber = DUNSNumber.Create(e.DUNSNumber);
                    break;

                case Events.Events.AssociateIsParentUpdated e:
                    IsParent = e.IsParent;
                    break;

                case Events.Events.AssociateLongNameUpdated e:
                    LongName = LongName.Create(e.LongName);
                    break;

                case Events.Events.AssociateShortNameUpdated e:
                    ShortName = ShortName.Create(e.ShortName);
                    break;

                case Events.Events.AssociateStatusUpdated e:
                    Status = (Status)e.Status;
                    break;

                case Events.Events.AssociateTypeUpdated e:
                    AssociateType = (AssociateType)e.AssociateType;
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