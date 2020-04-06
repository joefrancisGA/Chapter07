using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class AddressTypeDesc : EGMSString<AddressTypeDesc>
    {
        protected AddressTypeDesc() { }

        protected AddressTypeDesc(string text) : base(text) { }

        public static AddressTypeDesc FromString(string text)
        {
            // TODO - validation - check length?  etc?

            return new AddressTypeDesc(text);
        }
    }
}
