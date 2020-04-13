using System;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class OperatingContextCustomer : Entity<int>
    {
        public OperatingContextCustomer() { }
        public OperatingContextCustomer(Action<object> applier) : base(applier) { }


        public OperatingContext OperatingContext { get; set; }
        public int OperatingContextId { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }


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