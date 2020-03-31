using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class ContactPhone : Entity<DatabaseId>
    {
        public Contact Contact { get; set; }
        public DatabaseId ContactId { get; set; }

        public Phone Phone { get; set; }
        public DatabaseId PhoneId { get; set; }


        public ContactPhone() { }

        public ContactPhone(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}