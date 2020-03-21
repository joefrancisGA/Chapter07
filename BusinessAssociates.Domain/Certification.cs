using System;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;

namespace EGMS.BusinessAssociates.Domain
{
    public class Certification
    {
        public DatabaseId Id { get; set; }


        public bool IsInherited { get; set; }
        public CertificationStatus CertificationStatus { get; set; }
        public DateTime CertificationDateTime { get; set; }
        public DateTime DecertificationDateTime { get; set; }
    }
}
