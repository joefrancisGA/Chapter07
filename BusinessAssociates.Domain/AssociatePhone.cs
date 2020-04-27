using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AssociatePhone : Entity<DatabaseId>
    {
        public AssociatePhone() { }
        public AssociatePhone(Action<object> applier) : base(applier) { }

        public Associate Associate { get; set; }
        public DatabaseId AssociateId { get; set; }

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