using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AssociateEMail : Entity<DatabaseId>
    {
        public AssociateEMail() { }
        public AssociateEMail(Action<object> applier) : base(applier) { }

        public Associate Associate { get; set; }
        public DatabaseId AssociateId { get; set; }

        public EMail EMail { get; set; }
        public DatabaseId EMailId { get; set; }


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