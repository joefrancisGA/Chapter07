using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class BalancingLevelTypeDesc : EGMSString<BalancingLevelTypeDesc>
    {
        protected BalancingLevelTypeDesc() { }

        protected BalancingLevelTypeDesc(string text) : base(text) { }

        public static BalancingLevelTypeDesc FromString(string text)
        {
            // TODO - validation - check length?  etc?

            return new BalancingLevelTypeDesc(text);
        }
    }
}
