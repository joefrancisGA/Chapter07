using BusinessAssociates.Domain.Enums;

namespace BusinessAssociates.Domain
{
    public class Phone
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public PhoneType PhoneType { get; set; }
        public string Extension { get; set; }
        public bool IsPrimary { get; set; }
    }
}