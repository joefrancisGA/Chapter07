using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class IDMSAccountStatusName : EGMSString<IDMSAccountStatusName>
    {
        protected IDMSAccountStatusName() { }

        protected IDMSAccountStatusName(string text) : base(text) { }

        public static IDMSAccountStatusName FromString(string text)
        {
            // TODO - validation - check length?  etc?

            return new IDMSAccountStatusName(text);
        }
    }
}
