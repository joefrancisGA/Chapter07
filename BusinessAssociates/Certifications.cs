using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class Certifications
    {
        public Certifications()
        {
            OperatingContexts = new HashSet<OperatingContexts>();
        }

        public int Id { get; set; }
        public int CertificationStatusId { get; set; }
        public bool IsInherited { get; set; }
        public DateTime? CertificationDateTime { get; set; }
        public DateTime? DecertificationDateTime { get; set; }

        public virtual CertificationStatuses CertificationStatus { get; set; }
        public virtual ICollection<OperatingContexts> OperatingContexts { get; set; }
    }
}
