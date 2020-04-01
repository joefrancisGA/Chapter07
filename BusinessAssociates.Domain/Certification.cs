using System;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Certification : Entity<int>
    {
        public bool IsInherited { get; set; }
        public CertificationStatus CertificationStatus { get; set; }
        public DateTime CertificationDateTime { get; set; }
        public DateTime DecertificationDateTime { get; set; }


        public Certification() { }

        public Certification(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
