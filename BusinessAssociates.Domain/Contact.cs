using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Contact : Entity<DatabaseId>
    {
        public Contact(Action<object> applier) : base(applier)
        {
        }

        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public Title Title { get; set; }

        public User User { get; set; }


        public DatabaseId PrimaryPhoneId { get; set; }
        public DatabaseId PrimaryEmailIdId { get; set; }
        public DatabaseId PrimaryAddressId { get; set; }

        public List<Phone> Phones { get; set; }
        public List<EMail> Emails { get; set; }
        public List<Address> Addresses { get; set; }

        public bool IsActive { get; set; }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}