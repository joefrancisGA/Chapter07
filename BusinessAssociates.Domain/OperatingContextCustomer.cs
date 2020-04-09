using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class OperatingContextCustomer : Entity<DatabaseId>
    {
        public OperatingContextCustomer(Action<object> applier) : base(applier) { }

        public DatabaseId OperatingContextId { get; set; }
        public OperatingContext OperatingContext { get; set; }
        
        public DatabaseId CustomerId { get; set; }
        public Customer Customer { get; set; }

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