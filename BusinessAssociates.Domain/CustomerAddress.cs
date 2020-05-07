using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class CustomerAddress : Entity<DatabaseId>
    {
        public CustomerAddress() { }
        public CustomerAddress(Action<object> applier) : base(applier) { }

        public Customer Customer { get; set; }
        public DatabaseId CustomerId { get; set; }

        public Address Address { get; set; }
        public DatabaseId AddressId { get; set; }


        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            ParentHandler = parentHandler;
        }
    }
}