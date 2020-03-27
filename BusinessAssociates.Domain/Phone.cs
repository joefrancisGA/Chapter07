using System;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Phone : Entity<DatabaseId>
    {
        public DatabaseId UserId { get; set; }
        public PhoneType PhoneType { get; set; }
        public Extension Extension { get; set; }
        public bool IsPrimary { get; set; }

        public Phone(Action<object> applier) : base(applier)
        {
        }

        public Phone() { }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}