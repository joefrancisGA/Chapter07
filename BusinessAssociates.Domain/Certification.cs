using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Certification : Entity<int>
    {
        private Certification()
        {
            OperatingContexts = new HashSet<OperatingContext>();
        }

        public Certification(Action<object> applier) : base(applier)
        {
            OperatingContexts = new HashSet<OperatingContext>();
        }

        public bool IsInherited { get; set; }

        public CertificationStatusLookup CertificationStatus { get; set; }
        public int CertificationStatusId { get; set; }

        public DateTime CertificationDateTime { get; set; }
        public DateTime DecertificationDateTime { get; set; }
        

        public HashSet<OperatingContext> OperatingContexts;

        public static Certification Create(int certificationId, int certificationStatusId, DateTime certificationDateTime,
            DateTime decertificationDateTime, bool isInherited, int operatingContextId)
        {
            return new Certification
            {
                Id = certificationId,
                CertificationStatusId = certificationStatusId,
                CertificationDateTime = certificationDateTime,
                DecertificationDateTime = decertificationDateTime,
                IsInherited = isInherited
            };
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}
