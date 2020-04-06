using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class ContactPhone : Entity<int>
    {
        public Contact Contact { get; set; }
        public int ContactId { get; set; }

        public Phone Phone { get; set; }
        public int PhoneId { get; set; }


        public ContactPhone() { }

        public ContactPhone(Action<object> applier) : base(applier)
        {
        }

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