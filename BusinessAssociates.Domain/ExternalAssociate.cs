using System.Collections.Generic;
using BusinessAssociates.Domain.Enums;
using BusinessAssociates.Domain.ValueObjects;
using BusinessAssociates.Framework;

namespace BusinessAssociates.Domain
{
    public class ExternalAssociate : AggregateRoot<AssociateId>
    {
        // Properties in common with external business associates
        public Status Status { get; set; }

        public ExternalAssociate(DUNSNumber dunsNumber, LongName longName, ShortName shortName,
            ExternalAssociateType externalBusinessAssociateType) 
        {
            DUNSNumber = dunsNumber;
            LongName = longName;
            ShortName = shortName;
            ExternalBusinessAssociateType = externalBusinessAssociateType;
        }

        public ExternalAssociate(AssociateId id, string longName, string shortName, bool isParent,
            ExternalAssociateType externalAssociateType, Status status)
        {
            Events.ExternalAssociateCreated internalAssociateCreated = new Events.ExternalAssociateCreated
            {
                Id = id,
                LongName = longName,
                ShortName = shortName,
                IsParent = isParent,
                ExternalAssociateType = externalAssociateType,
                Status = status
            };

            Id = id;
            LongName = LongName.Create(longName);
            ShortName = ShortName.Create(shortName);
            IsParent = isParent;
            ExternalAssociateType = externalAssociateType;
            Status = status;

            Apply(internalAssociateCreated);
        }


        public ExternalAssociate() { }


        public void AddAgentRelationship(AgentRelationship agentRelationship)
        {
            if (AgentRelationships == null)
            {
                AgentRelationships = new List<AgentRelationship>();
            }

            AgentRelationships.Add(agentRelationship);
        }

        public void AddOperatingContext(OperatingContext context)
        {
            if (ExternalOperatingContexts == null)
            {
                ExternalOperatingContexts = new List<OperatingContext>();
            }

            ExternalOperatingContexts.Add(context);
        }

        public new long Id { get; set; }

        public bool IsParent { get; set; }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.ExternalAssociateCreated e:
                    Id = new AssociateId(e.Id);
                    break;

                case Events.ExternalAssociateDUNSNumberUpdated e:
                    DUNSNumber = DUNSNumber.Create(e.DUNSNumber);
                    break;

                case Events.ExternalAssociateIsParentUpdated e:
                    IsParent = e.IsParent;
                    break;

                case Events.ExternalAssociateLongNameUpdated e:
                    LongName = LongName.Create(e.LongName);
                    break;

                case Events.ExternalAssociateShortNameUpdated e:
                    ShortName = ShortName.Create(e.ShortName);
                    break;

                case Events.ExternalAssociateStatusUpdated e:
                    Status = (Status)e.Status;
                    break;

                case Events.ExternalAssociateTypeUpdated e:
                    ExternalAssociateType = (ExternalAssociateType)e.ExternalAssociateType;
                    break;
            }

        }

        protected override void EnsureValidState()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateDUNSNumber(DUNSNumber dunsNumber) =>
            Apply(new Events.ExternalAssociateDUNSNumberUpdated
                {
                    Id = Id,
                    DUNSNumber = dunsNumber
                }
            );

        public void UpdateExternalAssociateType(ExternalAssociateType externalAssociateType) =>
            Apply(new Events.ExternalAssociateTypeUpdated
                {
                    Id = Id,
                    ExternalAssociateType = (int)externalAssociateType
                }
            );

        public void UpdateLongName(LongName longName) => Apply(new Events.ExternalAssociateLongNameUpdated
                {
                    Id = Id,
                    LongName = longName.Value
                }
            );

        public void UpdateIsParent(bool isParent) => Apply(new Events.ExternalAssociateIsParentUpdated
                {
                    Id = Id,
                    IsParent = isParent
                }
            );

        public void UpdateStatus(Status status) => Apply(new Events.ExternalAssociateStatusUpdated
                {
                    Id = Id,
                    Status = (int)status
                }
            );

        public void UpdateShortName(ShortName shortName) => Apply(new Events.ExternalAssociateShortNameUpdated
                {
                    Id = Id,
                    ShortName = shortName.Value
                }
            );



        public DUNSNumber DUNSNumber { get; set; }
        public LongName LongName { get; set; }
        public ShortName ShortName { get; set; }
        public ExternalAssociateType ExternalAssociateType { get; set; }


        // Properties unique to external business associates
        public List<OperatingContext> ExternalOperatingContexts;
        public ExternalAssociateType ExternalBusinessAssociateType { get; set; }
        public List<ExternalAssociate> PredecessorBusinessAssociates { get; set; }
        public List<AgentRelationship> AgentRelationships { get; set; }
    }
}