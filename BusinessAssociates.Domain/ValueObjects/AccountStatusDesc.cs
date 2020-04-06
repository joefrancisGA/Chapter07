using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class AccountStatusDesc : EGMSString<AccountStatusDesc>
    {
        protected AccountStatusDesc() { }

        protected AccountStatusDesc(string text) : base(text) { }

        public static AccountStatusDesc FromString(string text)
        {
            // TODO - validation - check length?  etc?

            return new AccountStatusDesc(text);
        }
    }
}
