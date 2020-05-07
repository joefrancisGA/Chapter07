using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class AddressTypeLookup : Entity<int>
    {
        protected AddressTypeLookup() { }

        public enum AddressTypeEnum
        {
            Billing = 1,
            Curtailment = 2,
            Physical = 3
        }

        public static AddressTypeLookup GetAddressTypeLookup(AddressTypeEnum addressTypeEnum)
        {
            return new AddressTypeLookup
            {
                Id = (int) addressTypeEnum,
                AddressTypeId = (int) addressTypeEnum,
                Name = AddressTypeName.FromString(addressTypeEnum.ToString()),
                Desc = addressTypeEnum + " Description"
            };
        }

        public static readonly IReadOnlyDictionary<int, AddressTypeLookup> AddressTypes =
            new Dictionary<int, AddressTypeLookup>
            {
                { (int)AddressTypeEnum.Billing, GetAddressTypeLookup(AddressTypeEnum.Billing)},
                { (int) AddressTypeEnum.Curtailment, GetAddressTypeLookup(AddressTypeEnum.Curtailment)},
                { (int) AddressTypeEnum.Physical, GetAddressTypeLookup(AddressTypeEnum.Physical)}
            };

        public int AddressTypeId { get; private set; }

        public AddressTypeName Name { get; private set; }
        public string Desc { get; private set; }

        public List<Address> Addresses { get; set; }


        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(AddressTypeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}
