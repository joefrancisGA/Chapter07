﻿using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;


// TO DO:  Need to fix up ValueObjects
namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class ContactTypeLookup : Entity<int>
    {
        public enum ContactTypeEnum
        {
            Billing = 1,
            Curtailment = 2,
            Nomination = 3,
            Mailing = 4,
            Managerial = 5,
            Scheduler = 6,
            Trader = 7,
            Weekend = 8,
            OnCall = 9,
            Nominations = 10,
            Contract = 11,
            Technical = 12,
            Internal = 13,
            Operations = 14,
            Primary = 15,
            Service = 16,
            Other = 17
        }

        public static readonly
            IReadOnlyDictionary<int, ContactTypeLookup> ContactTypes =
                new Dictionary<int, ContactTypeLookup>
                {
                    {
                        (int) ContactTypeEnum.Billing,
                        new ContactTypeLookup
                        {
                            Id = (int) ContactTypeEnum.Billing,
                            ContactTypeId = (int) ContactTypeEnum.Billing,
                            Name = BalancingLevelTypeName.FromString("Billing"),
                            Desc = "Billing Description"
                        }
                    },
                    {
                        (int) ContactTypeEnum.Contract,
                        new ContactTypeLookup
                        {
                            Id = (int) ContactTypeEnum.Contract,
                            ContactTypeId = (int) ContactTypeEnum.Contract,
                            Name = BalancingLevelTypeName.FromString("Contract"),
                            Desc = "Contract Description"
                        }
                    },
                    {
                        (int) ContactTypeEnum.Curtailment,
                        new ContactTypeLookup
                        {
                            Id = (int) ContactTypeEnum.Curtailment,
                            ContactTypeId = (int) ContactTypeEnum.Curtailment,
                            Name = BalancingLevelTypeName.FromString("Curtailment"),
                            Desc = "Curtailment Description"
                        }
                    },
                    {
                        (int) ContactTypeEnum.Internal,
                        new ContactTypeLookup
                        {
                            Id = (int) ContactTypeEnum.Internal,
                            ContactTypeId = (int) ContactTypeEnum.Internal,
                            Name = BalancingLevelTypeName.FromString("Internal"),
                            Desc = "Internal Description"
                        }
                    },
                    {
                        (int) ContactTypeEnum.Mailing,
                        new ContactTypeLookup
                        {
                            Id = (int) ContactTypeEnum.Mailing,
                            ContactTypeId = (int) ContactTypeEnum.Mailing,
                            Name = BalancingLevelTypeName.FromString("Mailing"),
                            Desc = "Mailing Description"
                        }
                    },
                    {
                        (int) ContactTypeEnum.Managerial,
                        new ContactTypeLookup
                        {
                            Id = (int) ContactTypeEnum.Managerial,
                            ContactTypeId = (int) ContactTypeEnum.Managerial,
                            Name = BalancingLevelTypeName.FromString("Managerial"),
                            Desc = "Managerial Description"
                        }
                    },
                    {
                        (int) ContactTypeEnum.Internal,
                        new ContactTypeLookup
                        {
                            Id = (int) ContactTypeEnum.Nomination,
                            ContactTypeId = (int) ContactTypeEnum.Nomination,
                            Name = BalancingLevelTypeName.FromString("Nomination"),
                            Desc = "Nomination Description"
                        }
                    },
                    {
                        (int) ContactTypeEnum.Nominations,
                        new ContactTypeLookup
                        {
                            Id = (int) ContactTypeEnum.Nominations,
                            ContactTypeId = (int) ContactTypeEnum.Nominations,
                            Name = BalancingLevelTypeName.FromString("Nominations"),
                            Desc = "Nominations Description"
                        }
                    },
                    {
                        (int) ContactTypeEnum.OnCall,
                        new ContactTypeLookup
                        {
                            Id = (int) ContactTypeEnum.OnCall,
                            ContactTypeId = (int) ContactTypeEnum.OnCall,
                            Name = BalancingLevelTypeName.FromString("OnCall"),
                            Desc = "OnCall Description"
                        }
                    },
                    {
                        (int) ContactTypeEnum.Operations,
                        new ContactTypeLookup
                        {
                            Id = (int) ContactTypeEnum.Operations,
                            ContactTypeId = (int) ContactTypeEnum.Operations,
                            Name = BalancingLevelTypeName.FromString("Operations"),
                            Desc = "Operations Description"
                        }
                    },
                    {
                        (int) ContactTypeEnum.Other,
                        new ContactTypeLookup
                        {
                            Id = (int) ContactTypeEnum.Other,
                            ContactTypeId = (int) ContactTypeEnum.Other,
                            Name = BalancingLevelTypeName.FromString("Other"),
                            Desc = "Other Description"
                        }
                    }
                };

        public int ContactTypeId { get; private set; }

        public BalancingLevelTypeName Name { get; private set; }
        public string Desc { get; private set; }

        public List<ContactConfiguration> ContactConfigurations { get; set; }

        protected ContactTypeLookup() { }

        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(ContactTypeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            ParentHandler = parentHandler;
        }
    }
}
