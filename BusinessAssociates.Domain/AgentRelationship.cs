using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AgentRelationship : Entity<int>
    {
        private AgentRelationship()
        {
            AgentRelationshipUserList = new HashSet<AgentRelationshipUser>();
        }

        public AgentRelationship(Action<object> applier) : base(applier)
        {
            AgentRelationshipUserList = new HashSet<AgentRelationshipUser>();
        }

        public static AgentRelationship Create(int agentRelationshipId, bool isActive, DateTime endDate, int agentId, int principalId,
            DateTime startDate)
        {
            return new AgentRelationship
            {
                Id = agentRelationshipId,
                IsActive = isActive,
                EndDate = endDate,
                AgentId = agentId,
                PrincipalId = principalId,
                StartDate = startDate
            };
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

        // TO DO:  Use or eliminate
        public void AddAgentUser() { }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }

        // TO DO:  Why can't OnLoadInit be in the base class?
        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}