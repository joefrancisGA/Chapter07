using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AgentRelationship : Entity<DatabaseId>
    {
        //public AgentRelationship(Associate principal, Associate agent)
        //{
        //    Principal = principal;
        //    Agent = agent;
        //}

        public Associate Principal { get; set; }
        public Associate Agent { get; set; }
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

        public AgentRelationship(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}