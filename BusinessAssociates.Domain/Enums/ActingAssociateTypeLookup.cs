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
            Customer = 2,
            RegulatedUtility = 3,
            AssetManager = 4,
            Pipeline = 5
        }

        public static readonly
            IReadOnlyDictionary<int, ActingAssociateTypeLookup> ActingAssociateTypes =
                new Dictionary<int, ActingAssociateTypeLookup>
                {
                    {
                        (int) ActingAssociateTypeEnum.AssetManager,
                        new ActingAssociateTypeLookup
                        {
                            Id = (int) ActingAssociateTypeEnum.AssetManager,
                            ActingAssociateTypeId = (int) ActingAssociateTypeEnum.AssetManager,
                            Name = AssociateTypeName.FromString("AssetManager"),
                            Desc = AssociateTypeDesc.FromString("AssetManager Description"),
                        }
                    },
                    {
                        (int) ActingAssociateTypeEnum.Customer,
                        new ActingAssociateTypeLookup
                        {
                            Id = (int) ActingAssociateTypeEnum.Customer,
                            ActingAssociateTypeId = (int) ActingAssociateTypeEnum.Customer,
                            Name = AssociateTypeName.FromString("Customer"),
                            Desc = AssociateTypeDesc.FromString("Customer Description"),
                        }
                    },
                    {
                        (int) ActingAssociateTypeEnum.RegulatedUtility,
                        new ActingAssociateTypeLookup
                        {
                            Id = (int) ActingAssociateTypeEnum.RegulatedUtility,
                            ActingAssociateTypeId = (int) ActingAssociateTypeEnum.RegulatedUtility,
                            Name = AssociateTypeName.FromString("RegulatedUtility"),
                            Desc = AssociateTypeDesc.FromString("RegulatedUtility Description"),
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
                    },
                    {
                        (int) ActingAssociateTypeEnum.Pipeline,
                        new ActingAssociateTypeLookup
                        {
                            Id = (int) ActingAssociateTypeEnum.Pipeline,
                            ActingAssociateTypeId = (int) ActingAssociateTypeEnum.Pipeline,
                            Name = AssociateTypeName.FromString("Pipeline"),
                            Desc = AssociateTypeDesc.FromString("Pipeline Description"),
                        }
                    }
                };

        public int ActingAssociateTypeId { get; private set; }

        public AssociateTypeName Name { get; private set; }
        public AssociateTypeDesc Desc { get; private set; }

 
        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(ActingAssociateTypeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}
