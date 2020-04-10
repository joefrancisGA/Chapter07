using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Phone : Entity<int>
    {
        public Phone() { }
        public Phone(Action<object> applier) : base(applier) { }

        public DatabaseId UserId { get; set; }

        public PhoneTypeLookup PhoneType { get; set; }
        public int PhoneTypeId { get; set; }

        public Extension Extension { get; set; }
        public bool IsPrimary { get; set; }

        public Contact Contact { get; set; }
        public int ContactId { get; set; }

        public List<OperatingContext> OperatingContext { get; set; }


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