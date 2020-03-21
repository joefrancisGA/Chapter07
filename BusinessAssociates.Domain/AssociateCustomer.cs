using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AssociateCustomer : Entity<DatabaseId>
    {
        public AssociateId AssociateId { get; set; }
        public DatabaseId CustomerId { get; set; }

        public AssociateCustomer(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}