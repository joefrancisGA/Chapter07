﻿using System;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Address// : Entity<DatabaseId>
    {
        public AddressType AddressType { get; set; }
        public AddressLine Address1 { get; set; }
        public AddressLine Address2 { get; set; }
        public AddressLine Address3 { get; set; }
        public AddressLine Address4 { get; set; }
        public City City { get; set; }
        public GeographicState GeographicState { get; set; }
        public PostalCode PostalCode { get; set; }
        public CountryCode Country { get; set; }
        public Attention Attention { get; set; }
        public Comments Comments { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }

        //public Address(Action<object> applier) : base(applier)
        //{
        //}

        //protected override void When(object @event)
        //{
        //    throw new NotImplementedException();
        //}
    }
}