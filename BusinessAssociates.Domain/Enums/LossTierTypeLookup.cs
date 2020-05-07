using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;


// TO DO:  Need to fix up ValueObjects
namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class LossTierTypeLookup : Entity<int>
    {
        public enum LossTierTypeEnum
        {
            Unknown = 1
        }

        public static readonly
            IReadOnlyDictionary<int, LossTierTypeLookup> LossTierTypes =
                new Dictionary<int, LossTierTypeLookup>
                {
                    {
                        (int) LossTierTypeEnum.Unknown,
                        new LossTierTypeLookup
                        {
                            Id = (int) LossTierTypeEnum.Unknown,
                            LossTierTypeId = (int) LossTierTypeEnum.Unknown,
                            Name = BalancingLevelTypeName.FromString("Unknown"),
                            Desc = "Unknown Description"
                        }
                    }
                };

        public int LossTierTypeId { get; private set; }

        public BalancingLevelTypeName Name { get; private set; }
        public string Desc { get; private set; }

        public List<Customer> Customers { get; set; }

        protected LossTierTypeLookup() { }

        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(LossTierTypeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            ParentHandler = parentHandler;
        }
    }
}
