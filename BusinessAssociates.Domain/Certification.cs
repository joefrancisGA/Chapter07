using System;
using BusinessAssociates.Domain.Enums;

namespace BusinessAssociates.Domain
{
    public class Certification
    {
        public long Id { get; set; }


        public bool IsInherited { get; set; }
        public CertificationStatus CertificationStatus { get; set; }
        public DateTime CertificationDateTime { get; set; }
        public DateTime DecertificationDateTime { get; set; }
    }
}
