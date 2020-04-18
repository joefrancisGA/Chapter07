using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Phone : Entity<int>
    {
        private Phone()
        {
            OperatingContexts = new HashSet<OperatingContext>();
        }

        public Phone(Action<object> applier) : base(applier)
        {
            OperatingContexts = new HashSet<OperatingContext>();
        }

        public User User { get; set; }
        public int UserId { get; set; }

        public PhoneTypeLookup PhoneType { get; set; }
        public int PhoneTypeId { get; set; }

        public Extension Extension { get; set; }
        public bool IsPrimary { get; set; }

        public Contact Contact { get; set; }
        public int ContactId { get; set; }

        public HashSet<OperatingContext> OperatingContexts { get; set; }


        public static Phone Create(int phoneId, bool isPrimary, int contactId, int userId, Extension extension,
            PhoneTypeLookup phoneType)
        {
            return new Phone
            {
                Id = phoneId,
                IsPrimary = isPrimary,
                ContactId = contactId,
                UserId = userId,
                Extension = extension,
                PhoneType = phoneType
            };
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