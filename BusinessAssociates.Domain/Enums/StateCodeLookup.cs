using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class StateCodeLookup : Entity<int>
    {
        public enum StateCodeEnum
        {
            GA = 1
        }

        public static readonly
            IReadOnlyDictionary<int, StateCodeLookup> DeliveryTypes =
                new Dictionary<int, StateCodeLookup>
                {
                    {
                        (int) StateCodeEnum.GA,
                        new StateCodeLookup
                        {
                            Id = (int) StateCodeEnum.GA,
                            StateCodeId = (int) StateCodeEnum.GA,
                            Name = AddressTypeName.FromString("GA"),
                            Desc = AddressTypeDesc.FromString("GA Description"),
                        }
                    },
                };

        public int StateCodeId { get; private set; }

        public AddressTypeName Name { get; private set; }
        public AddressTypeDesc Desc { get; private set; }

        protected StateCodeLookup() { }

        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(DeliveryTypeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}
