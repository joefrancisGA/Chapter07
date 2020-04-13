namespace EGMS.BusinessAssociates.Query.ReadModels
{
    public class ContactRM
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public bool IsActive { get; set; }
        public string LastName { get; set; }
        public int PrimaryAddressId { get; set; }
        public int PrimaryEmailId { get; set; }
        public int PrimaryPhoneId { get; set; }
        public string Title { get; set; }
    }
}

