using System.Collections.Generic;
using BusinessAssociates.Domain.Enums;
using BusinessAssociates.Domain.ValueObjects;
using BusinessAssociates.Framework;
using EGMS.BusinessAssociate.Domain;

namespace BusinessAssociates.Domain
{
    public class ExternalAssociate : AggregateRoot<AssociateId>
    {
        public ExternalAssociate(DUNSNumber dunsNumber, LongName longName, ShortName shortName,
            ExternalAssociateType externalBusinessAssociateType) 
        {
            DUNSNumber = dunsNumber;
            LongName = longName;
            ShortName = shortName;
            ExternalBusinessAssociateType = externalBusinessAssociateType;
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

        public void AddOperatingContext(ExternalOperatingContext context)
        {
            if (ExternalOperatingContexts == null)
            {
                ExternalOperatingContexts = new List<ExternalOperatingContext>();
            }

            ExternalOperatingContexts.Add(context);
        }

        public new long Id { get; set; }
        protected override void When(object @event)
        {
            throw new System.NotImplementedException();
        }

        protected override void EnsureValidState()
        {
            throw new System.NotImplementedException();
        }


        public int DUNSNumber { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }


        // Properties unique to external business associates
        public List<ExternalOperatingContext> ExternalOperatingContexts;
        public ExternalAssociateType ExternalBusinessAssociateType { get; set; }
        public List<ExternalAssociate> PredecessorBusinessAssociates { get; set; }
        public List<AgentRelationship> AgentRelationships { get; set; }
    }
}