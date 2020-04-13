using System;
using EGMS.BusinessAssociates.Framework;


namespace EGMS.BusinessAssociates.Domain
{
    public class AgentUser : Entity<int>
    {
        public AgentUser() { }
        public AgentUser(Action<object> applier) : base(applier) { }

        public Associate Agent { get; set; }
        public int AgentId { get; set; }

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