using System;
using System.Collections.Generic;
using System.Text;
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
