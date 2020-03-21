using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class CustomerOperatingContext : Entity<DatabaseId>
    {
        public DatabaseId CustomerId { get; set; }
        public DatabaseId OperatingContextId { get; set; }

        public CustomerOperatingContext(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}