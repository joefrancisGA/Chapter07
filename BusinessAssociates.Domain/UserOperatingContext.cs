using System;

namespace BusinessAssociates.Domain
{
    public class UserOperatingContext : OperatingContext
    {
        public Role Role { get; set; }
        public int FacilityID { get; set; }
        public ExternalAssociate EgmsAssociate { get; set; }
        public User User { get; set; }


        // The specs call for StartDate, but that is inherited from 
        //   the generic OperatingContext

        public DateTime EndDate { get; set; }
    }
}