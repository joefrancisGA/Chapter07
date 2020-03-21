using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class ContactEMail : Entity<DatabaseId>
    {
        public DatabaseId ContactId { get; set; }
        public DatabaseId EMail { get; set; }

        public ContactEMail(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}