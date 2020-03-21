

using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class LastName : Value<LastName>
    {
        public string Value { get; }

        private LastName(string value)
        {
            Value = value;
        }

        public static LastName Create(string lastName)
        {
            return new LastName(lastName);
        }

        public static implicit operator string(LastName lastName)
        {
            return lastName.Value;
        }

        public static explicit operator LastName(string lastName)
        {
            return new LastName(lastName);
        }
    }
}