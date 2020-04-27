using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class CustomerEMail : Entity<DatabaseId>
    {
        public CustomerEMail() { }
        public CustomerEMail(Action<object> applier) : base(applier) { }

        public Customer Customer { get; set; }
        public DatabaseId CustomerId { get; set; }

        public EMail EMail { get; set; }
        public DatabaseId EMailId { get; set; }


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