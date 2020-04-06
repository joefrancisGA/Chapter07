using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class AddressTypeLookup : Entity<int>
    {
        public enum AddressTypeEnum
        {
            Billing = 1,
            Curtailment = 2,
            Physical = 3
        }

        public static readonly
            IReadOnlyDictionary<int, AddressTypeLookup> AddressTypes =
                new Dictionary<int, AddressTypeLookup>
                {
                    {
                        (int) AddressTypeEnum.Billing,
                        new AddressTypeLookup
                        {
                            Id = (int) AddressTypeEnum.Billing,
                            AddressTypeId = (int) AddressTypeEnum.Billing,
                            Name = AddressTypeName.FromString("Billing"),
                            Desc = AddressTypeDesc.FromString("Billing Description"),
                        }
                    },
                    {
                        (int) AddressTypeEnum.Curtailment,
                        new AddressTypeLookup
                        {
                            Id = (int) AddressTypeEnum.Curtailment,
                            AddressTypeId = (int) AddressTypeEnum.Curtailment,
                            Name = AddressTypeName.FromString("Curtailment"),
                            Desc = AddressTypeDesc.FromString("Curtailment Description"),
                        }
                    },
                    {
                        (int) AddressTypeEnum.Physical,
                        new AddressTypeLookup
                        {
                            Id = (int) AddressTypeEnum.Physical,
                            AddressTypeId = (int) AddressTypeEnum.Physical,
                            Name = AddressTypeName.FromString("Physical"),
                            Desc = AddressTypeDesc.FromString("Physical Description"),
                        }
                    }
                };

        public int AddressTypeId { get; private set; }

        public AddressTypeName Name { get; private set; }
        public AddressTypeDesc Desc { get; private set; }

        protected AddressTypeLookup() { }

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
