using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AgentRelationship : Entity<int>
    {
        public AgentRelationship() { }

        public AgentRelationship(Action<object> applier) : base(applier)
        {
        }

        public Associate Principal { get; set; }
        public int PrincipalId { get; set; }

        public Associate Agent { get; set; }
        public int AgentId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }


        // Collections
        public List<AgentRelationshipUser> AgentRelationshipUserList { get; set; }


        public void AddAgentUser()
        {
            if (AgentRelationshipUserList == null)
            {
                AgentRelationshipUserList = new List<AgentRelationshipUser>();
            }
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}