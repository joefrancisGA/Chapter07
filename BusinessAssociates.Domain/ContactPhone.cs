using System;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class ContactPhone : Entity<int>
    {
        public ContactPhone() { }
        public ContactPhone(Action<object> applier) : base(applier) { }

        public Contact Contact { get; set; }
        public int ContactId { get; set; }

        public Phone Phone { get; set; }
        public int PhoneId { get; set; }



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