using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class IDMSAccountStatusDesc : EGMSString<IDMSAccountStatusDesc>
    {
        protected IDMSAccountStatusDesc() { }

        protected IDMSAccountStatusDesc(string text) : base(text) { }

        public static IDMSAccountStatusDesc FromString(string text)
        {
            // TODO - validation - check length?  etc?

            return new IDMSAccountStatusDesc(text);
        }
    }
}
