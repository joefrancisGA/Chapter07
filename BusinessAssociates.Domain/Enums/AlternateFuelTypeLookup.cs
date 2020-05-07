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
                            AlternateFuelTypeId = (int) AlternateFuelTypeEnum.Coal,
                            Name = AlternateFuelTypeName.FromString("Coal"),
                            Desc = "Coal Description"
                        }
                    },
                    {
                        (int) AlternateFuelTypeEnum.Electricity,
                        new AlternateFuelTypeLookup
                        {
                            Id = (int) AlternateFuelTypeEnum.Electricity,
                            AlternateFuelTypeId = (int) AlternateFuelTypeEnum.Electricity,
                            Name = AlternateFuelTypeName.FromString("Electricity"),
                            Desc = "Electricity Description"
                        }
                    },
                    {
                        (int) AlternateFuelTypeEnum.Number2Oil,
                        new AlternateFuelTypeLookup
                        {
                            Id = (int) AlternateFuelTypeEnum.Number2Oil,
                            AlternateFuelTypeId = (int) AlternateFuelTypeEnum.Number2Oil,
                            Name = AlternateFuelTypeName.FromString("Number2Oil"),
                            Desc = "Number2Oil Description"
                        }
                    },
                    {
                        (int) AlternateFuelTypeEnum.Number4Oil,
                        new AlternateFuelTypeLookup
                        {
                            Id = (int) AlternateFuelTypeEnum.Number4Oil,
                            AlternateFuelTypeId = (int) AlternateFuelTypeEnum.Number4Oil,
                            Name = AlternateFuelTypeName.FromString("Number4Oil"),
                            Desc = "Number4Oil Description"
                        }
                    },
                    {
                        (int) AlternateFuelTypeEnum.Number5Oil,
                        new AlternateFuelTypeLookup
                        {
                            Id = (int) AlternateFuelTypeEnum.Number5Oil,
                            AlternateFuelTypeId = (int) AlternateFuelTypeEnum.Number5Oil,
                            Name = AlternateFuelTypeName.FromString("Number5Oil"),
                            Desc = "Number5Oil Description"
                        }
                    },
                    {
                        (int) AlternateFuelTypeEnum.Number6Oil,
                        new AlternateFuelTypeLookup
                        {
                            Id = (int) AlternateFuelTypeEnum.Number6Oil,
                            AlternateFuelTypeId = (int) AlternateFuelTypeEnum.Number6Oil,
                            Name = AlternateFuelTypeName.FromString("Number6Oil"),
                            Desc = "Number6Oil Description"
                        }
                    },
                    {
                        (int) AlternateFuelTypeEnum.Propane,
                        new AlternateFuelTypeLookup
                        {
                            Id = (int) AlternateFuelTypeEnum.Propane,
                            AlternateFuelTypeId = (int) AlternateFuelTypeEnum.Propane,
                            Name = AlternateFuelTypeName.FromString("Propane"),
                            Desc = "Propane Description"
                        }
                    },
                    {
                        (int) AlternateFuelTypeEnum.Wood,
                        new AlternateFuelTypeLookup
                        {
                            Id = (int) AlternateFuelTypeEnum.Wood,
                            AlternateFuelTypeId = (int) AlternateFuelTypeEnum.Wood,
                            Name = AlternateFuelTypeName.FromString("Wood"),
                            Desc = "Wood Description"
                        }
                    },
                    {
                        (int) AlternateFuelTypeEnum.Other,
                        new AlternateFuelTypeLookup
                        {
                            Id = (int) AlternateFuelTypeEnum.Other,
                            AlternateFuelTypeId = (int) AlternateFuelTypeEnum.Other,
                            Name = AlternateFuelTypeName.FromString("Other"),
                            Desc = "Other Description"
                        }
                    },
                };

        public int AlternateFuelTypeId { get; private set; }

        public AlternateFuelTypeName Name { get; private set; }
        public string Desc { get; private set; }

        public List<CustomerAlternateFuel> CustomerAlternateFuels { get; set; }

        protected AlternateFuelTypeLookup() { }

        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(AddressTypeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            ParentHandler = parentHandler;
        }
    }
}
