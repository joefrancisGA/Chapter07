using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class ProviderTypeLookup : Entity<int>
    {
        public enum ProviderTypeEnum
        {
            Marketer = 1,
            Pooler = 2,
            Shipper = 3,
            Supplier = 4,
            AssetManager = 5
        }

        public static readonly
            IReadOnlyDictionary<int, ProviderTypeLookup> ProviderTypes =
                new Dictionary<int, ProviderTypeLookup>
                {
                    {
                        (int) ProviderTypeEnum.Marketer,
                        new ProviderTypeLookup
                        {
                            Id = (int) ProviderTypeEnum.Marketer,
                            ProviderTypeId = (int) ProviderTypeEnum.Marketer,
                            Name = AddressTypeName.FromString("Marketer"),
                            Desc = "Marketer Description",
                        }
                    },
                    {
                        (int) ProviderTypeEnum.Pooler,
                        new ProviderTypeLookup
                        {
                            Id = (int) ProviderTypeEnum.Pooler,
                            ProviderTypeId = (int) ProviderTypeEnum.Pooler,
                            Name = AddressTypeName.FromString("Pooler"),
                            Desc = "Pooler Description"
                        }
                    },
                    {
                        (int) ProviderTypeEnum.Shipper,
                        new ProviderTypeLookup
                        {
                            Id = (int) ProviderTypeEnum.Shipper,
                            ProviderTypeId = (int) ProviderTypeEnum.Shipper,
                            Name = AddressTypeName.FromString("Shipper"),
                            Desc = "Shipper Description"
                        }
                    },
                    {
                    (int) ProviderTypeEnum.Supplier,
                    new ProviderTypeLookup
                    {
                        Id = (int) ProviderTypeEnum.Supplier,
                        ProviderTypeId = (int) ProviderTypeEnum.Supplier,
                        Name = AddressTypeName.FromString("Supplier"),
                        Desc = "Supplier Description"
                    }
                },
                    {
                        (int) ProviderTypeEnum.AssetManager,
                        new ProviderTypeLookup
                        {
                            Id = (int) ProviderTypeEnum.AssetManager,
                            ProviderTypeId = (int) ProviderTypeEnum.AssetManager,
                            Name = AddressTypeName.FromString("AssetManager"),
                            Desc = "AssetManager Description"
                        }
                    }
                };

        public int ProviderTypeId { get; private set; }

        public AddressTypeName Name { get; private set; }
        public string Desc { get; private set; }

        public List<OperatingContext> OperatingContexts { get; set; }

        protected ProviderTypeLookup() { }

        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(ProviderTypeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}
