using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;


// TO DO:  Need to fix up ValueObjects
namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class OperatingContextTypeLookup : Entity<int>
    {
        public enum OperatingContextTypeEnum
        {
            Internal = 1,
            External = 2,
            ActingBA = 3,
            Provider = 4
        }

        public static readonly
            IReadOnlyDictionary<int, OperatingContextTypeLookup> OperatingContextTypes =
                new Dictionary<int, OperatingContextTypeLookup>
                {
                    {
                        (int) OperatingContextTypeEnum.Internal,
                        new OperatingContextTypeLookup
                        {
                            Id = (int) OperatingContextTypeEnum.Internal,
                            OperatingContextTypeId = (int) OperatingContextTypeEnum.Internal,
                            Name = BalancingLevelTypeName.FromString("Internal"),
                            Desc = BalancingLevelTypeDesc.FromString("Internal Description"),
                        }
                    },
                    {
                    (int) OperatingContextTypeEnum.External,
                    new OperatingContextTypeLookup
                    {
                        Id = (int) OperatingContextTypeEnum.External,
                        OperatingContextTypeId = (int) OperatingContextTypeEnum.External,
                        Name = BalancingLevelTypeName.FromString("External"),
                        Desc = BalancingLevelTypeDesc.FromString("External Description"),
                    }
                },
                    {
                        (int) OperatingContextTypeEnum.ActingBA,
                        new OperatingContextTypeLookup
                        {
                            Id = (int) OperatingContextTypeEnum.ActingBA,
                            OperatingContextTypeId = (int) OperatingContextTypeEnum.ActingBA,
                            Name = BalancingLevelTypeName.FromString("ActingBA"),
                            Desc = BalancingLevelTypeDesc.FromString("ActingBA Description"),
                        }
                    },
                    {
                        (int) OperatingContextTypeEnum.Provider,
                        new OperatingContextTypeLookup
                        {
                            Id = (int) OperatingContextTypeEnum.Provider,
                            OperatingContextTypeId = (int) OperatingContextTypeEnum.Provider,
                            Name = BalancingLevelTypeName.FromString("Provider"),
                            Desc = BalancingLevelTypeDesc.FromString("Provider Description"),
                        }
                    }
                };

        public int OperatingContextTypeId { get; private set; }

        public BalancingLevelTypeName Name { get; private set; }
        public BalancingLevelTypeDesc Desc { get; private set; }

        public List<OperatingContext> OperatingContexts { get; set; }

        protected OperatingContextTypeLookup() { }

        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(OperatingContextTypeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}
