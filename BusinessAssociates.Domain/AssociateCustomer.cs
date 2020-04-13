using System;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AssociateCustomer : Entity<int>
    {
        public AssociateCustomer() { }
        public AssociateCustomer(Action<object> applier) : base(applier) { }

        public Associate Associate { get; set; }
        public int AssociateId { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public DateTime ServiceStartDate { get; set; }
        public DateTime ServiceEndDate { get; set; }


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