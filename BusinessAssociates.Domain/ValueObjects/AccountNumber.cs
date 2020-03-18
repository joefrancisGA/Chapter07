

using BusinessAssociates.Framework;

namespace BusinessAssociates.Domain.ValueObjects
{
    public class AccountNumber : Value<AccountNumber>
    {
        public string Value { get; }

        private AccountNumber(string value)
        {
            Value = value;
        }

        public static AccountNumber Create(string accountNumber)
        {
            return new AccountNumber(accountNumber);
        }

        public static implicit operator string(AccountNumber accountNumber)
        {
            return accountNumber.Value;
        }

        public static explicit operator AccountNumber(string accountNumber)
        {
            return new AccountNumber(accountNumber);
        }
    }
}