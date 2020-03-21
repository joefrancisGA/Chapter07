using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Contact : Entity<DatabaseId>
    {
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public Title Title { get; set; }

        public User User { get; set; }
        public DatabaseId PrimaryPhoneId { get; set; }
        public DatabaseId PrimaryEmailId { get; set; }
        public DatabaseId PrimaryAddressId { get; set; }

        public bool IsActive { get; set; }

        public Contact(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}