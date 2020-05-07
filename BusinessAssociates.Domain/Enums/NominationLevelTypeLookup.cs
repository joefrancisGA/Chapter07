using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class NominationLevelTypeLookup : Entity<int>
    {
        public enum NominationLevelTypeEnum
        {
            Customer = 1,
            Pool = 2,
            DeliveryGroup = 3
        }

        public static readonly
            IReadOnlyDictionary<int, NominationLevelTypeLookup> NominationLevelTypes =
                new Dictionary<int, NominationLevelTypeLookup>
                {
                    {
                        (int) NominationLevelTypeEnum.Customer,
                        new NominationLevelTypeLookup
                        {
                            Id = (int) NominationLevelTypeEnum.Customer,
                            NominationLevelTypeId = (int) NominationLevelTypeEnum.Customer,
                            Name = BalancingLevelTypeName.FromString("Customer"),
                            Desc = "Customer Description"
                        }
                    },
                    {
                        (int) NominationLevelTypeEnum.Pool,
                        new NominationLevelTypeLookup
                        {
                            Id = (int) NominationLevelTypeEnum.Pool,
                            NominationLevelTypeId = (int) NominationLevelTypeEnum.Pool,
                            Name = BalancingLevelTypeName.FromString("Pool"),
                            Desc = "Pool Description"
                        }
                    },
                    {
                        (int) NominationLevelTypeEnum.DeliveryGroup,
                        new NominationLevelTypeLookup
                        {
                            Id = (int) NominationLevelTypeEnum.DeliveryGroup,
                            NominationLevelTypeId = (int) NominationLevelTypeEnum.DeliveryGroup,
                            Name = BalancingLevelTypeName.FromString("DeliveryGroup"),
                            Desc = "DeliveryGroup Description"
                        }
                    }
                };

        public int NominationLevelTypeId { get; private set; }

        public BalancingLevelTypeName Name { get; private set; }
        public string Desc { get; private set; }

        public List<Customer> Customers { get; set; }

        protected NominationLevelTypeLookup() { }

        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(BalancingLevelTypeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            ParentHandler = parentHandler;
        }
    }
}
