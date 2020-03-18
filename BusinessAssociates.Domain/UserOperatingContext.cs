using System;

namespace BusinessAssociates.Domain
{
    public class UserOperatingContext
    {
        public int Id { get; set; }

        public Role Role { get; set; }
        public int FacilityID { get; set; }
        public User User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}