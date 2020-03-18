namespace BusinessAssociates.Domain
{
    public class Contact
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public User User { get; set; }
        public int PrimaryPhoneId { get; set; }
        public int PrimaryEmailId { get; set; }
        public int PrimaryAddressId { get; set; }
        public bool IsActive { get; set; }
    }
}