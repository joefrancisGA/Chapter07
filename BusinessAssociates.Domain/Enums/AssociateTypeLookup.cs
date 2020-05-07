using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class AssociateTypeLookup : Entity<int>
    {
        protected AssociateTypeLookup() { }
        
        public enum AssociateTypeEnum
        {
            InternalParent = 1,
            InternalOperatingCompany = 2,
            InternalLDCFacility = 3,
            SubordinateRegulatedProvider = 4,
            SubordinateUtilityProvider = 5,
            SubordinateDistinctUtilityProvider = 6
        }

        public static readonly
            IReadOnlyDictionary<int, AssociateTypeLookup> AssociateTypes =
                new Dictionary<int, AssociateTypeLookup>
                {
                    {
                        (int) AssociateTypeEnum.InternalLDCFacility,
                        new AssociateTypeLookup
                        {
                            Id = (int) AssociateTypeEnum.InternalLDCFacility,
                            AssociateTypeId = (int) AssociateTypeEnum.InternalLDCFacility,
                            Name = AssociateTypeName.FromString("InternalLDCFacility"),
                            Desc = "InternalLDCFacility Description"
                        }
                    },
                    {
                        (int) AssociateTypeEnum.InternalOperatingCompany,
                        new AssociateTypeLookup
                        {
                            Id = (int) AssociateTypeEnum.InternalOperatingCompany,
                            AssociateTypeId = (int) AssociateTypeEnum.InternalOperatingCompany,
                            Name = AssociateTypeName.FromString("InternalOperatingCompany"),
                            Desc = "InternalOperatingCompany Description"
                        }
                    },
                    {
                        (int) AssociateTypeEnum.InternalParent,
                        new AssociateTypeLookup
                        {
                            Id = (int) AssociateTypeEnum.InternalParent,
                            AssociateTypeId = (int) AssociateTypeEnum.InternalParent,
                            Name = AssociateTypeName.FromString("InternalParent"),
                            Desc = "InternalParent Description"
                        }
                    },
                    {
                        (int) AssociateTypeEnum.SubordinateDistinctUtilityProvider,
                        new AssociateTypeLookup
                        {
                            Id = (int) AssociateTypeEnum.SubordinateDistinctUtilityProvider,
                            AssociateTypeId = (int) AssociateTypeEnum.SubordinateDistinctUtilityProvider,
                            Name = AssociateTypeName.FromString("SubordinateDistinctUtilityProvider"),
                            Desc = "SubordinateDistinctUtilityProvider Description"
                        }
                    },
                    {
                        (int) AssociateTypeEnum.SubordinateRegulatedProvider,
                        new AssociateTypeLookup
                        {
                            Id = (int) AssociateTypeEnum.SubordinateRegulatedProvider,
                            AssociateTypeId = (int) AssociateTypeEnum.SubordinateRegulatedProvider,
                            Name = AssociateTypeName.FromString("SubordinateRegulatedFacility"),
                            Desc = "SubordinateRegulatedFacility Description"
                        }
                    },
                    {
                        (int) AssociateTypeEnum.SubordinateUtilityProvider,
                        new AssociateTypeLookup
                        {
                            Id = (int) AssociateTypeEnum.SubordinateUtilityProvider,
                            AssociateTypeId = (int) AssociateTypeEnum.SubordinateUtilityProvider,
                            Name = AssociateTypeName.FromString("SubordinateUtilityProvider"),
                            Desc = "SubordinateUtilityProvider Description"
                        }
                    },
                };

        public int AssociateTypeId { get; private set; }

        public AssociateTypeName Name { get; private set; }
        public string Desc { get; private set; }

 
        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(AssociateTypeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            ParentHandler = parentHandler;
        }
    }
}
