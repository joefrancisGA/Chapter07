using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class AccountStatusName : EGMSString<AccountStatusName>
    {
        protected AccountStatusName() { }

        protected AccountStatusName(string text) : base(text) { }

        public static AccountStatusName FromString(string text)
        {
            // TODO - validation - check length?  etc?

            return new AccountStatusName(text);
        }
    }
}
