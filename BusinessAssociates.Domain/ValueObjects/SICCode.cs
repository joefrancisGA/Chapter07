using System;
using BusinessAssociates.Framework;


namespace BusinessAssociates.Domain.ValueObjects
{
    public class SICCode : Value<SICCode>
    {
        public int Value { get; }

        public SICCode(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "SIC Code cannot be empty");
            
            Value = value;
        }

        public static implicit operator int(SICCode self) => self.Value;
        public static implicit operator SICCode(int value) => new SICCode(value);

        public override string ToString() => Value.ToString();
    }
}