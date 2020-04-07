using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class IDMSLinkTypeLookup : Entity<int>
    {
        public enum IDMSLinkTypeEnum
        {
            AddEGMS = 1,
            RemoveEGMS = 2,
            AddUserAccount = 3,
            DisableOrModifyUserAccount = 4,
            ReactivateUserAccount = 5
        }

        public static readonly
            IReadOnlyDictionary<int, IDMSLinkTypeLookup> DeliveryTypes =
                new Dictionary<int, IDMSLinkTypeLookup>
                {
                    {
                        (int) IDMSLinkTypeEnum.AddEGMS,
                        new IDMSLinkTypeLookup
                        {
                            Id = (int) IDMSLinkTypeEnum.AddEGMS,
                            IDMSLinkTypeId = (int) IDMSLinkTypeEnum.AddEGMS,
                            Name = AddressTypeName.FromString("AddEGMS"),
                            Desc = AddressTypeDesc.FromString("AddEGMS Description"),
                        }
                    },
                    {
                        (int) IDMSLinkTypeEnum.AddUserAccount,
                        new IDMSLinkTypeLookup
                        {
                            Id = (int) IDMSLinkTypeEnum.AddUserAccount,
                            IDMSLinkTypeId = (int) IDMSLinkTypeEnum.AddUserAccount,
                            Name = AddressTypeName.FromString("AddUserAccount"),
                            Desc = AddressTypeDesc.FromString("AddUserAccount Description"),
                        }
                    },
                    {
                        (int) IDMSLinkTypeEnum.DisableOrModifyUserAccount,
                        new IDMSLinkTypeLookup
                        {
                            Id = (int) IDMSLinkTypeEnum.DisableOrModifyUserAccount,
                            IDMSLinkTypeId = (int) IDMSLinkTypeEnum.DisableOrModifyUserAccount,
                            Name = AddressTypeName.FromString("DisableOrModifyUserAccount"),
                            Desc = AddressTypeDesc.FromString("DisableOrModifyUserAccount Description"),
                        }
                    },
                    {
                        (int) IDMSLinkTypeEnum.ReactivateUserAccount,
                        new IDMSLinkTypeLookup
                        {
                            Id = (int) IDMSLinkTypeEnum.ReactivateUserAccount,
                            IDMSLinkTypeId = (int) IDMSLinkTypeEnum.ReactivateUserAccount,
                            Name = AddressTypeName.FromString("ReactivateUserAccount"),
                            Desc = AddressTypeDesc.FromString("ReactivateUserAccount Description"),
                        }
                    },
                };

        public int IDMSLinkTypeId { get; private set; }

        public AddressTypeName Name { get; private set; }
        public AddressTypeDesc Desc { get; private set; }

        protected IDMSLinkTypeLookup() { }

        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(IDMSLinkTypeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}
