﻿using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class StateCodeLookup : Entity<int>
    {
        public enum StateCodeEnum
        {
            GA = 1
        }

        protected StateCodeLookup() { }

        public static readonly
            IReadOnlyDictionary<int, StateCodeLookup> StateCodes =
                new Dictionary<int, StateCodeLookup>
                {
                    {
                        (int) StateCodeEnum.GA,
                        new StateCodeLookup
                        {
                            Id = (int) StateCodeEnum.GA,
                            StateCodeId = (int) StateCodeEnum.GA,
                            Name = AddressTypeName.FromString("GA"),
                            Desc = "GA Description"
                        }
                    },
                };

        public int StateCodeId { get; private set; }

        public CountryCodeLookup CountryCode { get; set; }
        public int CountryCodeId { get; set; }

        public AddressTypeName Name { get; private set; }
        public string Desc { get; private set; }

        public List<Address> Addresses { get; set; }

        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(StateCodeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            ParentHandler = parentHandler;
        }
    }
}
