using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using BusinessAssociates.Domain.Enums;
using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class Address
    {
        public long Id { get; set; }
        public AddressType AddressType { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string City { get; set; }
        public GeographicState GeographicState { get; set; }
        public string PostalCode { get; set; }
        public CountryCode Country { get; set; }
        public string Attention { get; set; }
        public string Comments { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }
    }
}