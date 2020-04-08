using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class AlternateFuelTypeLookup : Entity<int>
    {
        public enum AlternateFuelTypeEnum
        {
            Electricity = 1,
            Wood = 2,
            Coal = 3,
            Propane = 4,
            Number2Oil = 5,
            Number4Oil = 6,
            Number5Oil = 7,
            Number6Oil = 8,
            Other = 9
        }

        public static readonly
            IReadOnlyDictionary<int, AlternateFuelTypeLookup> AddressTypes =
                new Dictionary<int, AlternateFuelTypeLookup>
                {
                    {
                        (int) AlternateFuelTypeEnum.Coal,
                        new AlternateFuelTypeLookup
                        {
                            Id = (int) AlternateFuelTypeEnum.Coal,
                            AddressTypeId = (int) AlternateFuelTypeEnum.Coal,
                            Name = AlternateFuelTypeName.FromString("Coal"),
                            Desc = AlternateFuelTypeDesc.FromString("Coal Description"),
                        }
                    },
                    {
                        (int) AlternateFuelTypeEnum.Electricity,
                        new AlternateFuelTypeLookup
                        {
                            Id = (int) AlternateFuelTypeEnum.Electricity,
                            AddressTypeId = (int) AlternateFuelTypeEnum.Electricity,
                            Name = AlternateFuelTypeName.FromString("Electricity"),
                            Desc = AlternateFuelTypeDesc.FromString("Electricity Description"),
                        }
                    },
                    {
                        (int) AlternateFuelTypeEnum.Number2Oil,
                        new AlternateFuelTypeLookup
                        {
                            Id = (int) AlternateFuelTypeEnum.Number2Oil,
                            AddressTypeId = (int) AlternateFuelTypeEnum.Number2Oil,
                            Name = AlternateFuelTypeName.FromString("Number2Oil"),
                            Desc = AlternateFuelTypeDesc.FromString("Number2Oil Description"),
                        }
                    },
                    {
                        (int) AlternateFuelTypeEnum.Number4Oil,
                        new AlternateFuelTypeLookup
                        {
                            Id = (int) AlternateFuelTypeEnum.Number4Oil,
                            AddressTypeId = (int) AlternateFuelTypeEnum.Number4Oil,
                            Name = AlternateFuelTypeName.FromString("Number4Oil"),
                            Desc = AlternateFuelTypeDesc.FromString("Number4Oil Description"),
                        }
                    },
                    {
                        (int) AlternateFuelTypeEnum.Number5Oil,
                        new AlternateFuelTypeLookup
                        {
                            Id = (int) AlternateFuelTypeEnum.Number5Oil,
                            AddressTypeId = (int) AlternateFuelTypeEnum.Number5Oil,
                            Name = AlternateFuelTypeName.FromString("Number5Oil"),
                            Desc = AlternateFuelTypeDesc.FromString("Number5Oil Description"),
                        }
                    },
                    {
                        (int) AlternateFuelTypeEnum.Number6Oil,
                        new AlternateFuelTypeLookup
                        {
                            Id = (int) AlternateFuelTypeEnum.Number6Oil,
                            AddressTypeId = (int) AlternateFuelTypeEnum.Number6Oil,
                            Name = AlternateFuelTypeName.FromString("Number6Oil"),
                            Desc = AlternateFuelTypeDesc.FromString("Number6Oil Description"),
                        }
                    },
                    {
                        (int) AlternateFuelTypeEnum.Propane,
                        new AlternateFuelTypeLookup
                        {
                            Id = (int) AlternateFuelTypeEnum.Propane,
                            AddressTypeId = (int) AlternateFuelTypeEnum.Propane,
                            Name = AlternateFuelTypeName.FromString("Propane"),
                            Desc = AlternateFuelTypeDesc.FromString("Propane Description"),
                        }
                    },
                    {
                        (int) AlternateFuelTypeEnum.Wood,
                        new AlternateFuelTypeLookup
                        {
                            Id = (int) AlternateFuelTypeEnum.Wood,
                            AddressTypeId = (int) AlternateFuelTypeEnum.Wood,
                            Name = AlternateFuelTypeName.FromString("Wood"),
                            Desc = AlternateFuelTypeDesc.FromString("Wood Description"),
                        }
                    },
                    {
                        (int) AlternateFuelTypeEnum.Other,
                        new AlternateFuelTypeLookup
                        {
                            Id = (int) AlternateFuelTypeEnum.Other,
                            AddressTypeId = (int) AlternateFuelTypeEnum.Other,
                            Name = AlternateFuelTypeName.FromString("Other"),
                            Desc = AlternateFuelTypeDesc.FromString("Other Description"),
                        }
                    },
                };

        public int AddressTypeId { get; private set; }

        public AlternateFuelTypeName Name { get; private set; }
        public AlternateFuelTypeDesc Desc { get; private set; }

        public List<CustomerAlternateFuel> CustomerAlternateFuels { get; set; }

        protected AlternateFuelTypeLookup() { }

        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(AddressTypeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}
