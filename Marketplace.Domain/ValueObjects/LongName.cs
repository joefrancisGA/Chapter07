

using BusinessAssociates.Framework;

namespace EGMS.BusinessAssociate.Domain.ValueObjects
{
    public class LongName : Value<LongName>
    {
        public string Value { get; }

        private LongName(string value)
        {
            Value = value;
        }

        public static implicit operator string(LongName longName)
        {
            return longName.Value;
        }

        public static explicit operator LongName(string longName)
        {
            return new LongName(longName);
        }
    }
}