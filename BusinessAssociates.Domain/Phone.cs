using System.Runtime.CompilerServices;
using BusinessAssociates.Domain.Enums;
using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class Phone
    {
        public DatabaseId Id { get; set; }

        public DatabaseId UserId { get; set; }
        public PhoneType PhoneType { get; set; }
        public Extension Extension { get; set; }
        public bool IsPrimary { get; set; }
    }
}