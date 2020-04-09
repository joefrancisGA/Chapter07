using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class EMail : Entity<int>
    {

        public EMail() { }
        public EMail(Action<object> applier) : base(applier) { }

        public int UserId { get; set; }
        public EMailAddress EMailAddress { get; set; }
        public bool IsPrimary { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }

        public List<OperatingContext> OperatingContexts { get; set; }

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