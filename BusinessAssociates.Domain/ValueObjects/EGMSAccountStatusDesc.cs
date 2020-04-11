using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class EGMSAccountStatusDesc : EGMSString<EGMSAccountStatusDesc>
    {
        protected EGMSAccountStatusDesc() { }
        protected EGMSAccountStatusDesc(string text) : base(text) { }

        public static EGMSAccountStatusDesc FromString(string text)
        {
            // TODO - validation - check length?  etc?

            return new EGMSAccountStatusDesc(text);
        }
    }
}
