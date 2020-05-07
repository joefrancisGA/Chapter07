using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class EGMSLinkTypeLookup : Entity<int>
    {
        public enum EGMSLinkTypeEnum
        {
            ConfigureUser = 1,
            ModifyUser = 2
        }

        protected EGMSLinkTypeLookup() { }

        public static readonly
            IReadOnlyDictionary<int, EGMSLinkTypeLookup> EGMSLinkTypes =
                new Dictionary<int, EGMSLinkTypeLookup>
                {
                    {
                        (int) EGMSLinkTypeEnum.ConfigureUser,
                        new EGMSLinkTypeLookup
                        {
                            Id = (int) EGMSLinkTypeEnum.ConfigureUser,
                            EGMSLinkTypeId = (int) EGMSLinkTypeEnum.ConfigureUser,
                            Name = AddressTypeName.FromString("ConfigureUser"),
                            Desc = "ConfigureUser Description"
                        }
                    },
                    {
                        (int) EGMSLinkTypeEnum.ModifyUser,
                        new EGMSLinkTypeLookup
                        {
                            Id = (int) EGMSLinkTypeEnum.ModifyUser,
                            EGMSLinkTypeId = (int) EGMSLinkTypeEnum.ModifyUser,
                            Name = AddressTypeName.FromString("ModifyUser"),
                            Desc = "ModifyUser Description"
                        }
                    },
                };

        public int EGMSLinkTypeId { get; private set; }

        public AddressTypeName Name { get; private set; }
        public string Desc { get; private set; }


        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(EGMSLinkTypeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            ParentHandler = parentHandler;
        }
    }
}
