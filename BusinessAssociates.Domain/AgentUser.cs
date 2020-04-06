using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AgentUser : Entity<DatabaseId>
    {
        public Associate Agent { get; set; }
        public AssociateId AgentId { get; set; }

        public User User { get; set; }
        public DatabaseId UserId { get; set; }

        public AgentUser()
        {
        }

        public AgentUser(Action<object> applier) : base(applier)
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