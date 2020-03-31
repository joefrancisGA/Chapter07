using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class ContactEMail : Entity<DatabaseId>
    {
        public Contact Contact { get; set; }
        public DatabaseId ContactId { get; set; }
        
        public EMail EMail { get; set; }
        public DatabaseId EMailId { get; set; }


        public ContactEMail()
        {
        }

        public ContactEMail(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}