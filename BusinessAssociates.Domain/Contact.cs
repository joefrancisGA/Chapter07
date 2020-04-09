using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Contact : Entity<int>
    {
        public Contact() { }
        public Contact(Action<object> applier) : base(applier) { }

        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public Title Title { get; set; }
 

        public Phone PrimaryPhone { get; set; }
        public int PrimaryPhoneId { get; set; }

        public EMail PrimaryEMail { get; set; }
        public int PrimaryEmailId { get; set; }

        public Address PrimaryAddress { get; set; }
        public int PrimaryAddressId { get; set; }

        public bool IsActive { get; set; }

        public List<ContactPhone> ContactPhones { get; set; }
        public List<EMail> Emails { get; set; }
        public List<Phone> Phones { get; set; }

        // TO:  Need a one-to-many reference to this field at the EF level
        public List<Address> Addresses { get; set; }
        public List<ContactConfiguration> ContactConfigurations { get; set; }
        public List<User> Users { get; set; }


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