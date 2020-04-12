using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class ActingAssociateTypeLookup : Entity<int>
    {
        protected ActingAssociateTypeLookup() { }


        public enum ActingAssociateTypeEnum
        {
            SelfProvider = 1,
            CustomerProvider = 2,
            RegulatedUtilityProvider = 3,
            AssetManagerProvider = 4
        }

        public static readonly
            IReadOnlyDictionary<int, ActingAssociateTypeLookup> ActingAssociateTypes =
                new Dictionary<int, ActingAssociateTypeLookup>
                {
                    {
                        (int) ActingAssociateTypeEnum.AssetManagerProvider,
                        new ActingAssociateTypeLookup
                        {
                            Id = (int) ActingAssociateTypeEnum.AssetManagerProvider,
                            ActingAssociateTypeId = (int) ActingAssociateTypeEnum.AssetManagerProvider,
                            Name = AssociateTypeName.FromString("AssetManagerProvider"),
                            Desc = AssociateTypeDesc.FromString("AssetManagerProvider Description"),
                        }
                    },
                    {
                        (int) ActingAssociateTypeEnum.CustomerProvider,
                        new ActingAssociateTypeLookup
                        {
                            Id = (int) ActingAssociateTypeEnum.CustomerProvider,
                            ActingAssociateTypeId = (int) ActingAssociateTypeEnum.CustomerProvider,
                            Name = AssociateTypeName.FromString("CustomerProvider"),
                            Desc = AssociateTypeDesc.FromString("CustomerProvider Description"),
                        }
                    },
                    {
                        (int) ActingAssociateTypeEnum.RegulatedUtilityProvider,
                        new ActingAssociateTypeLookup
                        {
                            Id = (int) ActingAssociateTypeEnum.RegulatedUtilityProvider,
                            ActingAssociateTypeId = (int) ActingAssociateTypeEnum.RegulatedUtilityProvider,
                            Name = AssociateTypeName.FromString("RegulatedUtilityProvider"),
                            Desc = AssociateTypeDesc.FromString("RegulatedUtilityProvider Description"),
                        }
                    },
                    {
                        (int) ActingAssociateTypeEnum.SelfProvider,
                        new ActingAssociateTypeLookup
                        {
                            Id = (int) ActingAssociateTypeEnum.SelfProvider,
                            ActingAssociateTypeId = (int) ActingAssociateTypeEnum.SelfProvider,
                            Name = AssociateTypeName.FromString("SelfProvider"),
                            Desc = AssociateTypeDesc.FromString("SelfProvider Description"),
                        }
                    }
                };

        public int ActingAssociateTypeId { get; private set; }

        public AssociateTypeName Name { get; private set; }
        public AssociateTypeDesc Desc { get; private set; }

 
        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(AssociateTypeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}
