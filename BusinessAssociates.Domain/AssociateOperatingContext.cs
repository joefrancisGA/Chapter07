using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AssociateOperatingContext : Entity<DatabaseId>
    {
        public AssociateId AssociateId { get; set; }
        public int OperatingContextId { get; set; }

        public AssociateOperatingContext(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}