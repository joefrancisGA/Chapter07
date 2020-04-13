using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AgentRelationship : Entity<int>
    {
        public AgentRelationship()
        {
            AgentRelationshipUserList = new HashSet<AgentRelationshipUser>();
        }

        public AgentRelationship(Action<object> applier) : base(applier)
        {
            AgentRelationshipUserList = new HashSet<AgentRelationshipUser>();
        }

        public Associate Principal { get; set; }
        public int PrincipalId { get; set; }

        public Associate Agent { get; set; }
        public int AgentId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }


        // Collections
        public HashSet<AgentRelationshipUser> AgentRelationshipUserList { get; set; }


        public void AddAgentUser()
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}