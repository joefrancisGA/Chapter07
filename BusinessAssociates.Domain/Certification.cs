﻿using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Certification : Entity<int>
    {
        public bool IsInherited { get; set; }
        public CertificationStatusLookup CertificationStatus { get; set; }
        public DateTime CertificationDateTime { get; set; }
        public DateTime DecertificationDateTime { get; set; }


        public Certification() { }

        public Certification(Action<object> applier) : base(applier)
        {
        }

        public List<OperatingContext> OperatingContexts;

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
