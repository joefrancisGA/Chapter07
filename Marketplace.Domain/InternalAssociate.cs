using System.Collections.Generic;
using BusinessAssociates.Domain.Enums;
using BusinessAssociates.Framework;

namespace BusinessAssociates.Domain
{
    public class InternalAssociate : AggregateRoot<AssociateId>
    {
        public Status Status { get; set; }


        public int DUNSNumber { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }

        // Collections
        public List<OperatingContext> OperatingContexts { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }


        // Properties unique to Internal Business Associate
        public InternalAssociateType InternalAssociateType { get; set; }
        private List<AssetManagerRelationship> AssetManagerRelationships { get; set; }

        // It is questionable whether we need this property
        // If the InternalBusinessAssociateType is Parent or OperatingCompany, 
        //   then we know it is a parent.
        public bool IsParent { get; set; }

        public InternalAssociate() { }

        public InternalAssociate(AssociateId id, string longName, string shortName, bool isParent, 
            InternalAssociateType internalAssociateType, Status status)
        {
            Events.InternalAssociateCreated internalAssociateCreated = new Events.InternalAssociateCreated
            {
                Id = id,
                LongName = longName,
                ShortName = shortName,
                IsParent = isParent,
                InternalAssociateType = internalAssociateType,
                Status = status
            };

            Id = id;
            LongName = longName;
            ShortName = shortName;
            IsParent = isParent;
            InternalAssociateType = internalAssociateType;
            Status = status;

            Apply(internalAssociateCreated);
        }

        public void UpdateText(InternalAssociateText text) =>
            Apply(new Events.InternalAssociateTextUpdated
                {
                    Id = Id
                }
            );

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.InternalAssociateCreated e:
                    Id = new AssociateId(e.Id);
                    break;

                case Events.InternalAssociateTextUpdated e:
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
                throw new InvalidEntityStateException(this, $"Post-checks failed");
        }

        public enum InternalAssociateState
        {
            PendingReview,
            Active,
            Inactive,
            MarkedAsSold
        }
    }
}