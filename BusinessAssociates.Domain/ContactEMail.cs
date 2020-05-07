using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class ContactEMail : Entity<DatabaseId>
    {
        public ContactEMail() { }
        public ContactEMail(Action<object> applier) : base(applier) { }

        public Contact Contact { get; set; }
        public int ContactId { get; set; }
        
        public EMail EMail { get; set; }
        public int EMailId { get; set; }

        
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