using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class CertificationLevelTypeDesc : EGMSString<CertificationLevelTypeDesc>
    {
        protected CertificationLevelTypeDesc() { }

        protected CertificationLevelTypeDesc(string text) : base(text) { }

        public static CertificationLevelTypeDesc FromString(string text)
        {
            // TODO - validation - check length?  etc?

            return new CertificationLevelTypeDesc(text);
        }
    }
}
