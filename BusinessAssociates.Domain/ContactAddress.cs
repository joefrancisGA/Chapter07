using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class ContactAddress : Entity<DatabaseId>
    {
        public Contact Contact { get; set; }
        public DatabaseId ContactId { get; set; }

        public Address Address { get; set; }
        public DatabaseId AddressId { get; set; }


        public ContactAddress () { }

        public ContactAddress(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}