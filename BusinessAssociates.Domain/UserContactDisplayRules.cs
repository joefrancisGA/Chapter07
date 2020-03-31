using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class UserContactDisplayRules : Entity<DatabaseId>
    {
        public UserContactDisplayRules() { }

        public UserContactDisplayRules(Action<object> applier) : base(applier)
        {
        }

        public bool IsInternal { get; set; }
        public bool IDMSAccountExists { get; set; }
        public bool IDMSAccountActive { get; set; }
        public bool EGMSConfigured { get; set; }
        public bool IsActive { get; set; }


        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}