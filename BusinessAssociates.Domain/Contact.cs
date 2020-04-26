using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Contact : Entity<int>
    {
        public Contact()
        {
            Initialize();
        }

        public Contact(Action<object> applier) : base(applier)
        {
            Initialize();
        }

        private void Initialize()
        {
            ContactPhones = new HashSet<ContactPhone>();
            Emails = new HashSet<EMail>();
            Phones = new HashSet<Phone>();
            Addresses = new HashSet<Address>();
            ContactConfigurations = new HashSet<ContactConfiguration>();
            Users = new HashSet<User>();
        }


        public static Contact Create(int contactId, int primaryAddressId, bool isActive, int primaryEMailId, int primaryPhoneId, 
            FirstName firstName, LastName lastName, Title title)
        {
            Contact contact = new Contact
            {
                Id = contactId,
                PrimaryAddressId = primaryAddressId,
                IsActive = isActive,
                PrimaryEmailId = primaryEMailId,
                PrimaryPhoneId = primaryPhoneId,
                FirstName = firstName,
                LastName = lastName,
                Title = title
            };

            return contact;
        }

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

        #region Collections
        public HashSet<ContactPhone> ContactPhones { get; set; }
        public HashSet<EMail> Emails { get; set; }
        public HashSet<Phone> Phones { get; set; }

        // TO:  Need a one-to-many reference to this field at the EF level
        public HashSet<Address> Addresses { get; set; }
        public HashSet<ContactConfiguration> ContactConfigurations { get; set; }
        public HashSet<User> Users { get; set; }

        #endregion

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