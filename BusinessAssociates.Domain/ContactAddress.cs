using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class ContactAddress : Entity<DatabaseId>
    {
        public ContactAddress() { }
        public ContactAddress(Action<object> applier) : base(applier) { }

        public Contact Contact { get; set; }
        public DatabaseId ContactId { get; set; }

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