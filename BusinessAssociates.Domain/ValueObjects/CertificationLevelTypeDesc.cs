using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;

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
