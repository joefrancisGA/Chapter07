using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class CustomerOperatingContext : Entity<DatabaseId>
    {
        public CustomerOperatingContext() { }
        public CustomerOperatingContext(Action<object> applier) : base(applier) { }


        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public OperatingContext OperatingContext { get; set; }
        public int OperatingContextId { get; set; }

        
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