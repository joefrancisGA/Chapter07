using System;

namespace BusinessAssociates.Domain
{
    public class User
    {
        public int Id { get; set; }

        public Contact Contact { get; set; }
        public string IDMSSID { get; set; }
        public string DepartmentCode { get; set; }
        public bool IsInternal { get; set; }
        public bool IsActive { get; set; }
        public bool HasEGMSAccess { get; set; }
        public DateTime DeactivationDate { get; set; }
    }
}