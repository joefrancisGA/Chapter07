using System;
using BusinessAssociates.Framework;


namespace BusinessAssociates.Domain.ValueObjects
{
    public class HourlyInterruptible : Value<HourlyInterruptible>
    {
        public int Value { get; }

        public HourlyInterruptible(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Hourly Interruptible cannot be empty");
            
            Value = value;
        }

        public static implicit operator int(HourlyInterruptible self) => self.Value;
        public static implicit operator HourlyInterruptible(int value) => new HourlyInterruptible(value);

        public override string ToString() => Value.ToString();
    }
}