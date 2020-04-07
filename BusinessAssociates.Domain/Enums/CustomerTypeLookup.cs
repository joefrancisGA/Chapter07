using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class CustomerTypeLookup : Entity<int>
    {
        public enum CustomerTypeEnum
        {
            Industrial = 1,
            Commercial = 2
        }

        public static readonly
            IReadOnlyDictionary<int, CustomerTypeLookup> AddressTypes =
                new Dictionary<int, CustomerTypeLookup>
                {
                    {
                        (int) CustomerTypeEnum.Industrial,
                        new CustomerTypeLookup
                        {
                            Id = (int) CustomerTypeEnum.Industrial,
                            CustomerTypeId = (int) CustomerTypeEnum.Industrial,
                            Name = AddressTypeName.FromString("Industrial"),
                            Desc = AddressTypeDesc.FromString("Industrial Description"),
                        }
                    },
                    {
                        (int) CustomerTypeEnum.Commercial,
                        new CustomerTypeLookup
                        {
                            Id = (int) CustomerTypeEnum.Commercial,
                            CustomerTypeId = (int) CustomerTypeEnum.Commercial,
                            Name = AddressTypeName.FromString("Commercial"),
                            Desc = AddressTypeDesc.FromString("Commercial Description"),
                        }
                    },
                };

        public int CustomerTypeId { get; private set; }

        public AddressTypeName Name { get; private set; }
        public AddressTypeDesc Desc { get; private set; }

        protected CustomerTypeLookup() { }

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
