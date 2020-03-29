using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AssociateOperatingContext : Entity<int>
    {
        public AssociateOperatingContext() { }


        public AssociateOperatingContext(int associateId, int operatingContextId)
        {
            AssociateId = associateId;
            OperatingContextId = operatingContextId;
        }


        public AssociateOperatingContext(Action<object> applier) : base(applier)
        {
        }

        public int AssociateId { get; set; }
        public Associate Associate { get; set; }

        public int OperatingContextId { get; set; }
        public OperatingContext OperatingContext { get; set; }

        
        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}