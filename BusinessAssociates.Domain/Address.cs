using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Address : Entity<int>
    {
        public Address() { }
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
        public Comments Comments { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }


        public List<OperatingContext> OperatingContexts { get; set; }

        public static Address Create(int addressId, bool isActive, DateTime endDate, AddressLine address1,
            AddressLine address2, AddressLine address3, AddressLine address4, bool isPrimary, AddressTypeLookup addressType,
            Attention attention, City city, Comments comments, PostalCode postalCode, StateCodeLookup stateCode)
        {
            Address address = new Address();

            address.Id = addressId;
            address.IsActive = isActive;
            address.EndDate = endDate;
            address.Address1 = address1;
            address.Address2 = address2;
            address.Address3 = address3;
            address.Address4 = address4;
            address.IsPrimary = isPrimary;
            address.AddressTypeId = addressType.AddressTypeId;
            address.Attention = attention;
            address.City = city;
            address.Comments = comments;
            address.PostalCode = postalCode;
            address.StateCodeId = stateCode.StateCodeId;

            return address;
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