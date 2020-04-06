using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Phone : Entity<int>
    {
        public DatabaseId UserId { get; set; }
        public PhoneType PhoneType { get; set; }
        public Extension Extension { get; set; }
        public bool IsPrimary { get; set; }

        public List<Contact> Contacts { get; set; }

        public Phone() { }

        public Phone(Action<object> applier) : base(applier)
        {
        }

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