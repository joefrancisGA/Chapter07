using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class LongName : Value<LongName>
    {
        public string Value { get; }

        public LongName() { }

        private LongName(string value)
        {
            Value = value;
        }

        public static LongName Create(string longName)
        {
            return new LongName(longName);
        }

        public static LongName FromString(string longName)
        {
            return new LongName(longName);
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