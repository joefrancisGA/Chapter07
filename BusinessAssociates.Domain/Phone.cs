using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
#pragma warning disable 660,661
    public class Phone : Entity<int>
#pragma warning restore 660,661
    {
        private Phone()
        {
            OperatingContexts = new HashSet<OperatingContext>();
        }

        public Phone(Action<object> applier) : base(applier)
        {
            OperatingContexts = new HashSet<OperatingContext>();
        }


        public PhoneTypeLookup PhoneType { get; set; }
        public int PhoneTypeId { get; set; }

        public long PhoneNumber { get; set; }

        public Extension Extension { get; set; }
        public bool IsPrimary { get; set; }

        public Contact Contact { get; set; }
        public int ContactId { get; set; }

        public Associate Associate { get; set; }
        public int AssociateId { get; set; }


        public HashSet<OperatingContext> OperatingContexts { get; set; }

        public static bool operator == (Phone phone1, Phone phone2)
        {
            if ((phone1 == null) && (phone2 == null))
                return true;

            if ((phone1 == null) || (phone2 == null))
                return false;

            if (phone1.PhoneTypeId != phone2.PhoneTypeId)
                return false;

            if (phone1.PhoneNumber != phone2.PhoneNumber)
                return false;

            if (phone1.Extension != phone2.Extension)
                return false;

            return true;
        }

        public static bool operator != (Phone phone1, Phone phone2)
        {
            return !(phone1 == phone2);
        }

        public static Phone CreateForContact(int phoneId, bool isPrimary, int contactId, Extension extension,
            PhoneTypeLookup phoneType)
        {
            return new Phone
            {
                Id = phoneId,
                IsPrimary = isPrimary,
                ContactId = contactId,
                Extension = extension,
                PhoneType = phoneType
            };
        }

        public static Phone CreateForAssociate(int phoneId, bool isPrimary, int associateId, Extension extension,
            PhoneTypeLookup phoneType)
        {
            return new Phone
            {
                Id = phoneId,
                IsPrimary = isPrimary,
                AssociateId = associateId,
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
            ParentHandler = parentHandler;
        }
    }
}