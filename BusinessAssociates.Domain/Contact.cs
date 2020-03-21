using EGMS.BusinessAssociates.Domain.ValueObjects;

namespace EGMS.BusinessAssociates.Domain
{
    public class Contact
    {
        public DatabaseId Id { get; set; }

        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public Title Title { get; set; }

        public User User { get; set; }
        public DatabaseId PrimaryPhoneId { get; set; }
        public DatabaseId PrimaryEmailId { get; set; }
        public DatabaseId PrimaryAddressId { get; set; }

        public bool IsActive { get; set; }
    }
}