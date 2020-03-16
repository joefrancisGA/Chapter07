using System.Dynamic;
using BusinessAssociates.Framework;

namespace BusinessAssociates.Domain.ValueObjects
{
    public class ShortName : Value<ShortName>
    {
        public string Value { get; }

        private ShortName(string value)
        {
            Value = value;
        }

        public static ShortName Create(string value)
        {
            return new ShortName(value);
        }

        public static implicit operator string(ShortName shortName)
        {
            return shortName.Value;
        }

        public static explicit operator ShortName(string shortName)
        {
            return new ShortName(shortName);
        }
    }
}