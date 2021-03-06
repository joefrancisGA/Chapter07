﻿using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class StatusCodeLookup : Entity<int>
    {
        protected StatusCodeLookup() { }


        public enum StatusCodeEnum
        {
            Pending = 1,
            Active = 2,
            Inactive = 3
        }

        public static readonly
            IReadOnlyDictionary<int, StatusCodeLookup> StatusCodes =
                new Dictionary<int, StatusCodeLookup>
                {
                    {
                        (int) StatusCodeEnum.Pending,
                        new StatusCodeLookup
                        {
                            Id = (int) StatusCodeEnum.Pending,
                            StatusCodeId = (int) StatusCodeEnum.Pending,
                            Name = AddressTypeName.FromString("Pending"),
                            Desc = "Pending Description"
                        }
                    },
                    {
                        (int) StatusCodeEnum.Active,
                        new StatusCodeLookup
                        {
                            Id = (int) StatusCodeEnum.Active,
                            StatusCodeId = (int) StatusCodeEnum.Active,
                            Name = AddressTypeName.FromString("Active"),
                            Desc = "Active Description"
                        }
                    },                    
                    {
                        (int) StatusCodeEnum.Inactive,
                        new StatusCodeLookup
                        {
                            Id = (int) StatusCodeEnum.Inactive,
                            StatusCodeId = (int) StatusCodeEnum.Inactive,
                            Name = AddressTypeName.FromString("Inactive"),
                            Desc = "Inactive Description"
                        }
                    }
                };

        public int StatusCodeId { get; private set; }

        public AddressTypeName Name { get; private set; }
        public string Desc { get; private set; }

        public List<Associate> Associates { get; set; }
        public List<ContactConfiguration> ContactConfigurations { get; set; }
        public List<Customer> Customers { get; set; }
        public List<OperatingContext> OperatingContexts { get; set; }


        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(StatusCodeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            ParentHandler = parentHandler;
        }
    }
}
