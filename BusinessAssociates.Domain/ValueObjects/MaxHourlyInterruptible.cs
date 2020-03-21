using System;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class MaxHourlyInterruptible : Value<MaxHourlyInterruptible>
    {
        public int Value { get; }

        public MaxHourlyInterruptible(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Max Hourly Interruptible cannot be empty");
            
            Value = value;
        }

        public static implicit operator int(MaxHourlyInterruptible self) => self.Value;
        public static implicit operator MaxHourlyInterruptible(int value) => new MaxHourlyInterruptible(value);

        public override string ToString() => Value.ToString();
    }
}