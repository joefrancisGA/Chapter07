using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class CertificationLevelTypeName : EGMSString<CertificationLevelTypeName>
    {
        protected CertificationLevelTypeName() { }

        protected CertificationLevelTypeName(string text) : base(text) { }

        public static CertificationLevelTypeName FromString(string text)
        {
            // TODO - validation - check length?  etc?

            return new CertificationLevelTypeName(text);
        }
    }
}
