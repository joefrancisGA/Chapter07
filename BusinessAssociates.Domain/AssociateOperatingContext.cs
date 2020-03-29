using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AssociateOperatingContext : Entity<DatabaseId>
    {
        public AssociateOperatingContext() { }


        public AssociateOperatingContext(AssociateId associateId, int operatingContextId)
        {
            AssociateId = associateId;
            OperatingContextId = operatingContextId;
        }


        public AssociateOperatingContext(Action<object> applier) : base(applier)
        {
        }

        public AssociateId AssociateId { get; set; }
        public Associate Associate { get; set; }

        public int OperatingContextId { get; set; }
        public OperatingContext OperatingContext { get; set; }

        
        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}