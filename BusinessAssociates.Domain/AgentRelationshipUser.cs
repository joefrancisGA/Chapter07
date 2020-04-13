using System;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AgentRelationshipUser : Entity<int>
    {
        public AgentRelationshipUser() { }
        public AgentRelationshipUser(Action<object> applier) : base(applier) { }

        public AgentRelationship AgentRelationship { get; set; }
        public int AgentRelationshipId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }


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