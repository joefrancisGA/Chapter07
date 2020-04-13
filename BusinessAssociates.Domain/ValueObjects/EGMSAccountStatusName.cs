using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class EGMSAccountStatusName : EGMSString<EGMSAccountStatusName>
    {
        protected EGMSAccountStatusName() { }
        protected EGMSAccountStatusName(string text) : base(text) { }

        public static EGMSAccountStatusName FromString(string text)
        {
            // TODO - validation - check length?  etc?

            return new EGMSAccountStatusName(text);
        }
    }
}
