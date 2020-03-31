using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AgentRelationship : Entity<DatabaseId>
    {
        public AgentRelationship() { }

        public AgentRelationship(Action<object> applier) : base(applier)
        {
        }

        public Associate Principal { get; set; }
        public AssociateId PrincipalId { get; set; }

        public Associate Agent { get; set; }
        public AssociateId AgentId { get; set; }

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