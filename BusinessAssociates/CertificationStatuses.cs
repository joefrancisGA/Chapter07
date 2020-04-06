using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class CertificationStatuses
    {
        public CertificationStatuses()
        {
            Certifications = new HashSet<Certifications>();
        }

        public int Id { get; set; }
        public string CertificationStatusName { get; set; }
        public string CertificationStatusDescription { get; set; }

        public virtual ICollection<Certifications> Certifications { get; set; }
    }
}
