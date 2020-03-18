using System;
using BusinessAssociates.Framework;


namespace BusinessAssociates.Domain.ValueObjects
{
    public class SICCodePercentage : Value<SICCodePercentage>
    {
        public int Value { get; }

        public SICCodePercentage(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "SIC Code Percentage cannot be empty");
            
            Value = value;
        }

        public static implicit operator int(SICCodePercentage self) => self.Value;
        public static implicit operator SICCodePercentage(int value) => new SICCodePercentage(value);

        public override string ToString() => Value.ToString();
    }
}