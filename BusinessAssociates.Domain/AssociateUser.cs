using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AssociateUser : Entity<DatabaseId>
    {
        public AssociateId AssociateId { get; set; }
        public DatabaseId UserId { get; set; }

        public AssociateUser(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}