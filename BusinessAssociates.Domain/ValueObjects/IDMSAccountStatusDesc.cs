using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class IDMSAccountStatusDesc : EGMSString<IDMSAccountStatusDesc>
    {
        protected IDMSAccountStatusDesc() { }

        protected IDMSAccountStatusDesc(string text) : base(text) { }

        public static IDMSAccountStatusDesc FromString(string text)
        {
            // TODO - validation - check length?  etc?

            return new IDMSAccountStatusDesc(text);
        }
    }
}
