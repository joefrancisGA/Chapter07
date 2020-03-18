using System;
using BusinessAssociates.Domain.Enums;

namespace BusinessAssociates.Domain
{
    public class ContactConfiguration
    {
        public int Id { get; set; }

        public int ContactId { get; set; }
        public int FacilityId { get; set; }
        public ContactType ContactType { get; set; }
        public int Priority { get; set; }
        public Status Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}