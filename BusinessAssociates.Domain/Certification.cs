using System;
using BusinessAssociates.Domain.Enums;
using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
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
