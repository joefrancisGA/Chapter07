using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AssociateCustomer : Entity<DatabaseId>
    {
        public Associate Associate { get; set; }
        public AssociateId AssociateId { get; set; }

        public Customer Customer { get; set; }
        public DatabaseId CustomerId { get; set; }


        public AssociateCustomer() { }

        public AssociateCustomer(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}