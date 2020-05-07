using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class DeliveryTypeLookup : Entity<int>
    {
        public enum DeliveryTypeEnum
        {
            Firm = 1,
            Interruptible = 2
        }

        public static readonly
            IReadOnlyDictionary<int, DeliveryTypeLookup> DeliveryTypes =
                new Dictionary<int, DeliveryTypeLookup>
                {
                    {
                        (int) DeliveryTypeEnum.Firm,
                        new DeliveryTypeLookup
                        {
                            Id = (int) DeliveryTypeEnum.Firm,
                            DeliveryTypeId = (int) DeliveryTypeEnum.Firm,
                            Name = AddressTypeName.FromString("Firm"),
                            Desc ="Firm Description"
                        }
                    },
                    {
                        (int) DeliveryTypeEnum.Interruptible,
                        new DeliveryTypeLookup
                        {
                            Id = (int) DeliveryTypeEnum.Interruptible,
                            DeliveryTypeId = (int) DeliveryTypeEnum.Interruptible,
                            Name = AddressTypeName.FromString("Interruptible"),
                            Desc = "Interruptible Description"
                        }
                    },
                };

        public int DeliveryTypeId { get; private set; }

        public AddressTypeName Name { get; private set; }
        public string Desc { get; private set; }

        public List<Customer> Customers { get; set; }

        protected DeliveryTypeLookup() { }

        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(DeliveryTypeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            ParentHandler = parentHandler;
        }
    }
}
