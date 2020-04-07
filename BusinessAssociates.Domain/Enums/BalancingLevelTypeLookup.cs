using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class BalancingLevelTypeLookup : Entity<int>
    {
        public enum BalancingLevelTypeEnum
        {
            Customer = 1,
            Group = 2,
            TPS = 3
        }

        public static readonly
            IReadOnlyDictionary<int, BalancingLevelTypeLookup> BalancingLevelTypes =
                new Dictionary<int, BalancingLevelTypeLookup>
                {
                    {
                        (int) BalancingLevelTypeEnum.Customer,
                        new BalancingLevelTypeLookup
                        {
                            Id = (int) BalancingLevelTypeEnum.Customer,
                            BalancingLevelTypeId = (int) BalancingLevelTypeEnum.Customer,
                            Name = BalancingLevelTypeName.FromString("Customer"),
                            Desc = BalancingLevelTypeDesc.FromString("Customer Description"),
                        }
                    },
                    {
                        (int) BalancingLevelTypeEnum.Group,
                        new BalancingLevelTypeLookup
                        {
                            Id = (int) BalancingLevelTypeEnum.Group,
                            BalancingLevelTypeId = (int) BalancingLevelTypeEnum.Group,
                            Name = BalancingLevelTypeName.FromString("Group"),
                            Desc = BalancingLevelTypeDesc.FromString("Group Description"),
                        }
                    },
                    {
                        (int) BalancingLevelTypeEnum.TPS,
                        new BalancingLevelTypeLookup
                        {
                            Id = (int) BalancingLevelTypeEnum.TPS,
                            BalancingLevelTypeId = (int) BalancingLevelTypeEnum.TPS,
                            Name = BalancingLevelTypeName.FromString("TPS"),
                            Desc = BalancingLevelTypeDesc.FromString("TPS Description"),
                        }
                    },
                };

        public int BalancingLevelTypeId { get; private set; }

        public BalancingLevelTypeName Name { get; private set; }
        public BalancingLevelTypeDesc Desc { get; private set; }

        protected BalancingLevelTypeLookup() { }

        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(BalancingLevelTypeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}
