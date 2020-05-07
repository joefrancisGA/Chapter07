using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;


// TO DO:  Need to fix up ValueObjects
namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class GroupTypeLookup : Entity<int>
    {
        public enum GroupTypeEnum
        {
            LocationBased = 1,
            DeliveryGroup = 2,
            None = 3
        }

        public static readonly
            IReadOnlyDictionary<int, GroupTypeLookup> GroupTypes =
                new Dictionary<int, GroupTypeLookup>
                {
                    {
                        (int) GroupTypeEnum.LocationBased,
                        new GroupTypeLookup
                        {
                            Id = (int) GroupTypeEnum.LocationBased,
                            GroupTypeId = (int) GroupTypeEnum.LocationBased,
                            Name = BalancingLevelTypeName.FromString("LocationBased"),
                            Desc = "LocationBased Description"
                        }
                    },
                    {
                        (int) GroupTypeEnum.DeliveryGroup,
                        new GroupTypeLookup
                        {
                            Id = (int) GroupTypeEnum.DeliveryGroup,
                            GroupTypeId = (int) GroupTypeEnum.DeliveryGroup,
                            Name = BalancingLevelTypeName.FromString("DeliveryGroup"),
                            Desc = "DeliveryGroup Description"
                        }
                    },
                    {
                        (int) GroupTypeEnum.None,
                        new GroupTypeLookup
                        {
                            Id = (int) GroupTypeEnum.None,
                            GroupTypeId = (int) GroupTypeEnum.None,
                            Name = BalancingLevelTypeName.FromString("None"),
                            Desc = "None Description"
                        }
                    }
                };

        public int GroupTypeId { get; private set; }

        public BalancingLevelTypeName Name { get; private set; }
        public string Desc { get; private set; }

        public List<Customer> Customers { get; set; }

        protected GroupTypeLookup() { }

        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(GroupTypeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}
