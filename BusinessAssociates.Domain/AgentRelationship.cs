using System;
using System.Collections.Generic;
using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class AgentRelationship
    {
        public AgentRelationship(ExternalAssociate principal, ExternalAssociate agent) : this()
        {
            Principal = principal;
            Agent = agent;
        }

        public AgentRelationship()
        {
            AgentUserList = new List<UserOperatingContext>();
        }

        public DatabaseId Id { get; set; }

        public ExternalAssociate Principal { get; set; }
        public ExternalAssociate Agent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        // Collections
        public List<UserOperatingContext> AgentUserList { get; set; }


        public void AddAgentUser()
        {
            if (AgentUserList == null)
            {
                AgentUserList = new List<UserOperatingContext>();
            }
        }
    }
}