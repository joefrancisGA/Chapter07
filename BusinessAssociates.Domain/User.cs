using System;
using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class User
    {
        public DatabaseId Id { get; set; }

        public Contact Contact { get; set; }
        public IDMSSID IDMSSID { get; set; }
        public DepartmentCode DepartmentCode { get; set; }

        public bool IsInternal { get; set; }
        public bool IsActive { get; set; }
        public bool HasEGMSAccess { get; set; }
        public DateTime DeactivationDate { get; set; }
    }
}