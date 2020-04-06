using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class AssociateTypeDesc : EGMSString<AssociateTypeDesc>
    {
        protected AssociateTypeDesc() { }

        protected AssociateTypeDesc(string text) : base(text) { }

        public static AssociateTypeDesc FromString(string text)
        {
            // TODO - validation - check length?  etc?

            return new AssociateTypeDesc(text);
        }
    }
}
