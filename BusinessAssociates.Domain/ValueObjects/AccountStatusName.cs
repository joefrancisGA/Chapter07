using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class AccountStatusName : EGMSString<AccountStatusName>
    {
        protected AccountStatusName() { }

        protected AccountStatusName(string text) : base(text) { }

        public static AccountStatusName FromString(string text)
        {
            // TODO - validation - check length?  etc?

            return new AccountStatusName(text);
        }
    }
}
