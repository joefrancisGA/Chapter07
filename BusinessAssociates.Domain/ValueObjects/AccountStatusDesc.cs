using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class AccountStatusDesc : EGMSString<AccountStatusDesc>
    {
        protected AccountStatusDesc() { }

        protected AccountStatusDesc(string text) : base(text) { }

        public static AccountStatusDesc FromString(string text)
        {
            // TODO - validation - check length?  etc?

            return new AccountStatusDesc(text);
        }
    }
}
