using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class PhoneTypeLookup : Entity<int>
    {
        public enum PhoneTypeEnum
        {
            Office = 1,
            Mobile = 2,
            Home = 3,
            Fax = 4
        }

        public static readonly
            IReadOnlyDictionary<int, PhoneTypeLookup> PhoneTypes =
                new Dictionary<int, PhoneTypeLookup>
                {
                    {
                        (int) PhoneTypeEnum.Office,
                        new PhoneTypeLookup
                        {
                            Id = (int) PhoneTypeEnum.Office,
                            PhoneTypeId = (int) PhoneTypeEnum.Office,
                            Name = AddressTypeName.FromString("Office"),
                            Desc = "Office Description"
                        }
                    },
                    {
                        (int) PhoneTypeEnum.Mobile,
                        new PhoneTypeLookup
                        {
                            Id = (int) PhoneTypeEnum.Mobile,
                            PhoneTypeId = (int) PhoneTypeEnum.Mobile,
                            Name = AddressTypeName.FromString("Mobile"),
                            Desc = "Mobile Description"
                        }
                    },
                    {
                        (int) PhoneTypeEnum.Home,
                        new PhoneTypeLookup
                        {
                            Id = (int) PhoneTypeEnum.Home,
                            PhoneTypeId = (int) PhoneTypeEnum.Home,
                            Name = AddressTypeName.FromString("Home"),
                            Desc = "Home Description"
                        }
                    },
                    {
                    (int) PhoneTypeEnum.Fax,
                    new PhoneTypeLookup
                    {
                        Id = (int) PhoneTypeEnum.Fax,
                        PhoneTypeId = (int) PhoneTypeEnum.Fax,
                        Name = AddressTypeName.FromString("Fax"),
                        Desc = "Fax Description",
                    }
                }
                };

        public int PhoneTypeId { get; private set; }

        public AddressTypeName Name { get; private set; }
        public string Desc { get; private set; }

        public List<Phone> Phones { get; set; }

        protected PhoneTypeLookup() { }

        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(PhoneTypeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}
