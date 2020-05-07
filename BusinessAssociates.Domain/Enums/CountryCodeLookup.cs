using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class CountryCodeLookup : Entity<int>
    {
        public enum CountryCodeEnum
        {
            UnitedStates = 1,
            Canada = 2,
            Mexico = 3,
        }

        protected CountryCodeLookup() { }

        public static readonly
            IReadOnlyDictionary<int, CountryCodeLookup> CountryCodes =
                new Dictionary<int, CountryCodeLookup>
                {
                    {
                        (int) CountryCodeEnum.UnitedStates,
                        new CountryCodeLookup
                        {
                            Id = (int) CountryCodeEnum.UnitedStates,
                            CountryCodeId = (int) CountryCodeEnum.UnitedStates,
                            Name = AssociateTypeName.FromString("UnitedStates"),
                            Desc = "UnitedStates Description"
                        }
                    },
                    {
                        (int) CountryCodeEnum.Canada,
                        new CountryCodeLookup
                        {
                            Id = (int) CountryCodeEnum.Canada,
                            CountryCodeId = (int) CountryCodeEnum.Canada,
                            Name = AssociateTypeName.FromString("Canada"),
                            Desc = "Canada Description"
                        }
                    },
                    {
                        (int) CountryCodeEnum.Mexico,
                        new CountryCodeLookup
                        {
                            Id = (int) CountryCodeEnum.Mexico,
                            CountryCodeId = (int) CountryCodeEnum.Mexico,
                            Name = AssociateTypeName.FromString("Mexico"),
                            Desc = "Mexico Description"
                        }
                    },
                };

        public int CountryCodeId { get; private set; }

        public AssociateTypeName Name { get; private set; }
        public string Desc { get; private set; }

        public List<StateCodeLookup> StateCodes { get; set; }

        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(CountryCodeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            ParentHandler = parentHandler;
        }
    }
}
