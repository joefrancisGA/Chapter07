using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;

namespace EGMS.BusinessAssociates.Domain
{
    public class UserOperatingContext
    {
        public DatabaseId Id { get; set; }

        public Role Role { get; set; }
        public DatabaseId FacilityID { get; set; }
        public User User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}