using System;
using System.Net.Security;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class CustomerOperatingContext : Entity<DatabaseId>
    {
        public Customer Customer { get; set; }
        public DatabaseId CustomerId { get; set; }

        public OperatingContext OperatingContext { get; set; }
        public DatabaseId OperatingContextId { get; set; }


        public CustomerOperatingContext() { }

        public CustomerOperatingContext(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}