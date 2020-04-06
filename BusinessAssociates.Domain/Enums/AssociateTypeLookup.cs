using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class AssociateTypeLookup : Entity<int>
    {
        public enum AssociateTypeEnum
        {
            InternalParent = 1,
            InternalOperatingCompany = 2,
            InternalLDCFacility = 3,
            ExternalSelfProvider = 4,
            ExternalCustomerProvider = 5,
            ExternalRegulatedUtilityProvider = 6,
            ExternalAssetManagerProvider = 7,
            SubordinateRegulatedProvider = 8,
            SubordinateUtilityProvider = 9,
            SubordinateDistinctUtilityProvider = 10
        }

        public static readonly
            IReadOnlyDictionary<int, AssociateTypeLookup> AssociateTypes =
                new Dictionary<int, AssociateTypeLookup>
                {
                    {
                        (int) AssociateTypeEnum.ExternalAssetManagerProvider,
                        new AssociateTypeLookup
                        {
                            Id = (int) AssociateTypeEnum.ExternalAssetManagerProvider,
                            AssociateTypeId = (int) AssociateTypeEnum.ExternalAssetManagerProvider,
                            Name = AssociateTypeName.FromString("ExternalAssetManagerProvider"),
                            Desc = AssociateTypeDesc.FromString("ExternalAssetManagerProvider Description"),
                        }
                    },
                    {
                        (int) AssociateTypeEnum.ExternalCustomerProvider,
                        new AssociateTypeLookup
                        {
                            Id = (int) AssociateTypeEnum.ExternalCustomerProvider,
                            AssociateTypeId = (int) AssociateTypeEnum.ExternalCustomerProvider,
                            Name = AssociateTypeName.FromString("ExternalCustomerProvider"),
                            Desc = AssociateTypeDesc.FromString("ExternalCustomerProvider Description"),
                        }
                    },
                    {
                        (int) AssociateTypeEnum.ExternalRegulatedUtilityProvider,
                        new AssociateTypeLookup
                        {
                            Id = (int) AssociateTypeEnum.ExternalRegulatedUtilityProvider,
                            AssociateTypeId = (int) AssociateTypeEnum.ExternalRegulatedUtilityProvider,
                            Name = AssociateTypeName.FromString("ExternalRegulatedUtilityProvider"),
                            Desc = AssociateTypeDesc.FromString("ExternalRegulatedUtilityProvider Description"),
                        }
                    },
                    {
                        (int) AssociateTypeEnum.ExternalSelfProvider,
                        new AssociateTypeLookup
                        {
                            Id = (int) AssociateTypeEnum.ExternalSelfProvider,
                            AssociateTypeId = (int) AssociateTypeEnum.ExternalSelfProvider,
                            Name = AssociateTypeName.FromString("ExternalSelfProvider"),
                            Desc = AssociateTypeDesc.FromString("ExternalSelfProvider Description"),
                        }
                    },
                    {
                        (int) AssociateTypeEnum.InternalLDCFacility,
                        new AssociateTypeLookup
                        {
                            Id = (int) AssociateTypeEnum.InternalLDCFacility,
                            AssociateTypeId = (int) AssociateTypeEnum.InternalLDCFacility,
                            Name = AssociateTypeName.FromString("InternalLDCFacility"),
                            Desc = AssociateTypeDesc.FromString("InternalLDCFacility Description"),
                        }
                    },
                    {
                        (int) AssociateTypeEnum.InternalOperatingCompany,
                        new AssociateTypeLookup
                        {
                            Id = (int) AssociateTypeEnum.InternalOperatingCompany,
                            AssociateTypeId = (int) AssociateTypeEnum.InternalOperatingCompany,
                            Name = AssociateTypeName.FromString("InternalOperatingCompany"),
                            Desc = AssociateTypeDesc.FromString("InternalOperatingCompany Description"),
                        }
                    },
                    {
                        (int) AssociateTypeEnum.InternalParent,
                        new AssociateTypeLookup
                        {
                            Id = (int) AssociateTypeEnum.InternalParent,
                            AssociateTypeId = (int) AssociateTypeEnum.InternalParent,
                            Name = AssociateTypeName.FromString("InternalParent"),
                            Desc = AssociateTypeDesc.FromString("InternalParent Description"),
                        }
                    },
                    {
                        (int) AssociateTypeEnum.SubordinateDistinctUtilityProvider,
                        new AssociateTypeLookup
                        {
                            Id = (int) AssociateTypeEnum.SubordinateDistinctUtilityProvider,
                            AssociateTypeId = (int) AssociateTypeEnum.SubordinateDistinctUtilityProvider,
                            Name = AssociateTypeName.FromString("SubordinateDistinctUtilityProvider"),
                            Desc = AssociateTypeDesc.FromString("SubordinateDistinctUtilityProvider Description"),
                        }
                    },
                    {
                        (int) AssociateTypeEnum.SubordinateRegulatedProvider,
                        new AssociateTypeLookup
                        {
                            Id = (int) AssociateTypeEnum.SubordinateRegulatedProvider,
                            AssociateTypeId = (int) AssociateTypeEnum.SubordinateRegulatedProvider,
                            Name = AssociateTypeName.FromString("SubordinateRegulatedFacility"),
                            Desc = AssociateTypeDesc.FromString("SubordinateRegulatedFacility Description"),
                        }
                    },
                    {
                        (int) AssociateTypeEnum.SubordinateUtilityProvider,
                        new AssociateTypeLookup
                        {
                            Id = (int) AssociateTypeEnum.SubordinateUtilityProvider,
                            AssociateTypeId = (int) AssociateTypeEnum.SubordinateUtilityProvider,
                            Name = AssociateTypeName.FromString("SubordinateUtilityProvider"),
                            Desc = AssociateTypeDesc.FromString("SubordinateUtilityProvider Description"),
                        }
                    },
                };

        public int AssociateTypeId { get; private set; }

        public AssociateTypeName Name { get; private set; }
        public AssociateTypeDesc Desc { get; private set; }

        protected AssociateTypeLookup() { }

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
