using System;
using System.Collections.Generic;
using BusinessAssociates.Domain;

namespace EGMS.BusinessAssociate.Domain
{
    public class AgentRelationship
    {
        public AgentRelationship(ExternalAssociate principal, Agent agent) : this()
        {
            Principal = principal;
            Agent = agent;
        }

        public AgentRelationship()
        {
            AgentUserList = new List<UserOperatingContext>();
        }

        public long Id { get; set; }

        public ExternalAssociate Principal { get; set; }
        public Agent Agent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        public List<UserOperatingContext> AgentUserList
        {
            get; set;
        }

        public ICollection<Agent> ExternalAssociateAgents { get; set; }
    }
}