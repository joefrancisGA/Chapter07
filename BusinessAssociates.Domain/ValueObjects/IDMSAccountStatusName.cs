using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class IDMSAccountStatusName : EGMSString<IDMSAccountStatusName>
    {
        protected IDMSAccountStatusName() { }

        protected IDMSAccountStatusName(string text) : base(text) { }

        public static IDMSAccountStatusName FromString(string text)
        {
            // TODO - validation - check length?  etc?

            return new IDMSAccountStatusName(text);
        }
    }
}
