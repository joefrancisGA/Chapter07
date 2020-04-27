using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class CustomerPhone : Entity<DatabaseId>
    {
        public CustomerPhone() { }
        public CustomerPhone(Action<object> applier) : base(applier) { }

        public Customer Customer { get; set; }
        public DatabaseId CustomerId { get; set; }

        public Phone Phone { get; set; }
        public DatabaseId PhoneId { get; set; }


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