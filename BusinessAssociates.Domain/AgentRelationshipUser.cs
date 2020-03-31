using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AgentRelationshipUser : Entity<DatabaseId>
    {
        public AgentRelationship AgentRelationship { get; set; }
        public DatabaseId AgentRelationshipId { get; set; }

        public User User { get; set; }
        public DatabaseId UserId { get; set; }

        public AgentRelationshipUser()
        {
        }

        public AgentRelationshipUser(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}