using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class AssociateTypeName : EGMSString<AssociateTypeName>
    {
        protected AssociateTypeName() { }

        protected AssociateTypeName(string text) : base(text) { }

        public static AssociateTypeName FromString(string text)
        {
            // TODO - validation - check length?  etc?

            return new AssociateTypeName(text);
        }
    }
}
