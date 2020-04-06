﻿using System;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class ContactConfiguration : Entity<DatabaseId>
    {
        public Contact Contact { get; set; }
        public DatabaseId ContactId { get; set; }

        public DatabaseId FacilityId { get; set; }
        public ContactType ContactType { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public ContactConfiguration() { }

        public ContactConfiguration(Action<object> applier) : base(applier)
        {
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