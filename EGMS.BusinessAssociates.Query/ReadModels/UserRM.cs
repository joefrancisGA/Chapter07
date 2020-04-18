using System;

namespace EGMS.BusinessAssociates.Query.ReadModels
{
    public class UserRM
    {
        public int Id { get; set; }

        public int ContactId { get; set; }
        public string IDMSSID { get; set; }
        public int DepartmentCodeId { get; set; }
        public bool IsInternal { get; set; }
        public bool IsActive { get; set; }
        public bool HasEGMSAccess { get; set; }
        public DateTime DeactivationDate { get; set; }
    }
}