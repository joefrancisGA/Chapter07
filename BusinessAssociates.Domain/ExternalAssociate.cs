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
            AssociateType externalBusinessAssociateType) 
        {
            DUNSNumber = dunsNumber;
            LongName = longName;
            ShortName = shortName;
            ExternalAssociateType = externalBusinessAssociateType;
        }

        public ExternalAssociate(AssociateId id, string longName, string shortName, bool isParent,
            AssociateType externalAssociateType, Status status)
        {
            Events.Events.ExternalAssociateCreated internalAssociateCreated = new Events.Events.ExternalAssociateCreated
            {
                Id = id.Value,
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

        public bool IsParent { get; set; }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.Events.ExternalAssociateCreated e:
                    Id = new AssociateId(e.Id);
                    break;

                case Events.Events.ExternalAssociateDUNSNumberUpdated e:
                    DUNSNumber = DUNSNumber.Create(e.DUNSNumber);
                    break;

                case Events.Events.ExternalAssociateIsParentUpdated e:
                    IsParent = e.IsParent;
                    break;

                case Events.Events.ExternalAssociateLongNameUpdated e:
                    LongName = LongName.Create(e.LongName);
                    break;

                case Events.Events.ExternalAssociateShortNameUpdated e:
                    ShortName = ShortName.Create(e.ShortName);
                    break;

                case Events.Events.ExternalAssociateStatusUpdated e:
                    Status = (Status)e.Status;
                    break;

                case Events.Events.ExternalAssociateTypeUpdated e:
                    ExternalAssociateType = (AssociateType)e.ExternalAssociateType;
                    break;
            }

        }

        protected override void EnsureValidState()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateDUNSNumber(DUNSNumber dunsNumber) =>
            Apply(new Events.Events.ExternalAssociateDUNSNumberUpdated
                {
                    Id = Id.Value,
                    DUNSNumber = dunsNumber
                }
            );

        public void UpdateExternalAssociateType(AssociateType externalAssociateType) =>
            Apply(new Events.Events.ExternalAssociateTypeUpdated
                {
                    Id = Id.Value,
                    ExternalAssociateType = (int)externalAssociateType
                }
            );

        public void UpdateLongName(LongName longName) => Apply(new Events.Events.ExternalAssociateLongNameUpdated
                {
                    Id = Id.Value,
                    LongName = longName.Value
                }
            );

        public void UpdateIsParent(bool isParent) => Apply(new Events.Events.ExternalAssociateIsParentUpdated
                {
                    Id = Id.Value,
                    IsParent = isParent
                }
            );

        public void UpdateStatus(Status status) => Apply(new Events.Events.ExternalAssociateStatusUpdated
                {
                    Id = Id.Value,
                    Status = (int)status
                }
            );

        public void UpdateShortName(ShortName shortName) => Apply(new Events.Events.ExternalAssociateShortNameUpdated
            {
                Id = Id.Value,
                ShortName = shortName.Value
            }
        );

        
        public DUNSNumber DUNSNumber { get; set; }
        public LongName LongName { get; set; }
        public ShortName ShortName { get; set; }
        public AssociateType ExternalAssociateType { get; set; }


        // Properties unique to external business associates
        public List<OperatingContext> ExternalOperatingContexts;
        public List<ExternalAssociate> PredecessorBusinessAssociates { get; set; }
        public List<AgentRelationship> AgentRelationships { get; set; }
    }
}