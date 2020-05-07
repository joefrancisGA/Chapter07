using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class ExternalAssociateTypeLookup : Entity<int>
    {
        protected ExternalAssociateTypeLookup() { }

        public enum ExternalAssociateTypeEnum
        {
            SelfProvider = 1,
            Customer = 2,
            RegulatedUtility = 3,
            AssetManager = 4,
            Pipeline = 5
        }

        public static readonly
            IReadOnlyDictionary<int, ExternalAssociateTypeLookup> ActingAssociateTypes =
                new Dictionary<int, ExternalAssociateTypeLookup>
                {
                    {
                        (int) ExternalAssociateTypeEnum.AssetManager,
                        new ExternalAssociateTypeLookup
                        {
                            Id = (int) ExternalAssociateTypeEnum.AssetManager,
                            ActingAssociateTypeId = (int) ExternalAssociateTypeEnum.AssetManager,
                            Name = AssociateTypeName.FromString("AssetManager"),
                            Desc = "AssetManager Description"
                        }
                    },
                    {
                        (int) ExternalAssociateTypeEnum.Customer,
                        new ExternalAssociateTypeLookup
                        {
                            Id = (int) ExternalAssociateTypeEnum.Customer,
                            ActingAssociateTypeId = (int) ExternalAssociateTypeEnum.Customer,
                            Name = AssociateTypeName.FromString("Customer"),
                            Desc = "Customer Description"
                        }
                    },
                    {
                        (int) ExternalAssociateTypeEnum.RegulatedUtility,
                        new ExternalAssociateTypeLookup
                        {
                            Id = (int) ExternalAssociateTypeEnum.RegulatedUtility,
                            ActingAssociateTypeId = (int) ExternalAssociateTypeEnum.RegulatedUtility,
                            Name = AssociateTypeName.FromString("RegulatedUtility"),
                            Desc = "RegulatedUtility Description"
                        }
                    },
                    {
                        (int) ExternalAssociateTypeEnum.SelfProvider,
                        new ExternalAssociateTypeLookup
                        {
                            Id = (int) ExternalAssociateTypeEnum.SelfProvider,
                            ActingAssociateTypeId = (int) ExternalAssociateTypeEnum.SelfProvider,
                            Name = AssociateTypeName.FromString("SelfProvider"),
                            Desc = "SelfProvider Description"
                        }
                    },
                    {
                        (int) ExternalAssociateTypeEnum.Pipeline,
                        new ExternalAssociateTypeLookup
                        {
                            Id = (int) ExternalAssociateTypeEnum.Pipeline,
                            ActingAssociateTypeId = (int) ExternalAssociateTypeEnum.Pipeline,
                            Name = AssociateTypeName.FromString("Pipeline"),
                            Desc = "Pipeline Description"
                        }
                    }
                };

        public int ActingAssociateTypeId { get; private set; }

        public AssociateTypeName Name { get; private set; }
        public string Desc { get; private set; }

 
        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(ExternalAssociateTypeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            ParentHandler = parentHandler;
        }
    }
}
