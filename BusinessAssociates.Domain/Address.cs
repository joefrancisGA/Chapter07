﻿using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Address : Entity<int>
    {
        protected bool Equals(Address other)
        {
            return AddressTypeId == other.AddressTypeId && Equals(Address1, other.Address1) && Equals(Address2, other.Address2) && Equals(Address3, other.Address3) && Equals(Address4, other.Address4) && Equals(City, other.City) && StateCodeId == other.StateCodeId && Equals(PostalCode, other.PostalCode) && Equals(Country, other.Country) && Equals(Attention, other.Attention);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Address) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(AddressTypeId);
            hashCode.Add(Address1);
            hashCode.Add(Address2);
            hashCode.Add(Address3);
            hashCode.Add(Address4);
            hashCode.Add(City);
            hashCode.Add(StateCodeId);
            hashCode.Add(PostalCode);
            hashCode.Add(Country);
            hashCode.Add(Attention);
            return hashCode.ToHashCode();
        }

        private Address() { }
        public Address(Action<object> applier) : base(applier) { }

        public AddressTypeLookup AddressType { get; set; }
        public int AddressTypeId { get; set; }

        public AddressLine Address1 { get; set; }
        public AddressLine Address2 { get; set; }
        public AddressLine Address3 { get; set; }
        public AddressLine Address4 { get; set; }
        public City City { get; set; }

        public int StateCodeId { get; set; }
        public StateCodeLookup StateCode { get; set; }
        public PostalCode PostalCode { get; set; }
        public CountryCodeLookup Country { get; set; }
        public Attention Attention { get; set; }
        public string Comments { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }


        public static bool operator == (Address address1, Address address2)
        {
            if (ReferenceEquals(null, address1))
                return ReferenceEquals(null, address2);

            if (ReferenceEquals(null, address2))
                return false;

            if (address1.AddressType != address2.AddressType)
                return false;

            if (address1.Address1 != address2.Address1)
                return false;

            if (address1.Address2 != address2.Address2)
                return false;
            
            if (address1.Address3 != address2.Address3)
                return false;
            
            if (address1.Address4 != address2.Address4)
                return false;
            
            if (address1.City != address2.City)
                return false;
            
            if (address1.PostalCode != address2.PostalCode)
                return false;
            
            if (address1.StateCodeId != address2.StateCodeId)
                return false;

            return true;
        }

        public static bool operator !=(Address address1, Address address2)
        {
            return !(address1 == address2);
        }

        public List<OperatingContext> OperatingContexts { get; set; }

        public static Address Create(int addressId, bool isActive, DateTime endDate, AddressLine address1,
            AddressLine address2, AddressLine address3, AddressLine address4, bool isPrimary, AddressTypeLookup addressType,
            Attention attention, City city, string comments, PostalCode postalCode, StateCodeLookup stateCode)
        {
            return new Address
            {
                Id = addressId,
                IsActive = isActive,
                EndDate = endDate,
                Address1 = address1,
                Address2 = address2,
                Address3 = address3,
                Address4 = address4,
                IsPrimary = isPrimary,
                AddressTypeId = addressType.AddressTypeId,
                Attention = attention,
                City = city,
                Comments = comments,
                PostalCode = postalCode,
                StateCodeId = stateCode.StateCodeId
            };
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            ParentHandler = parentHandler;
        }
    }
}