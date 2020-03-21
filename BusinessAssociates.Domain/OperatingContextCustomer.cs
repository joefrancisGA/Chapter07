using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class OperatingContextCustomer : Entity<DatabaseId>
    {
        public DatabaseId OperatingContextId { get; set; }
        public DatabaseId CustomerId { get; set; }

        public OperatingContextCustomer(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}