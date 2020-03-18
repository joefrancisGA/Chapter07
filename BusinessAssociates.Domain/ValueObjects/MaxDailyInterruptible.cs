using System;
using BusinessAssociates.Framework;


namespace BusinessAssociates.Domain.ValueObjects
{
    public class MaxDailyInterruptible : Value<MaxDailyInterruptible>
    {
        public int Value { get; }

        public MaxDailyInterruptible(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Max Daily Interruptible cannot be empty");
            
            Value = value;
        }

        public static implicit operator int(MaxDailyInterruptible self) => self.Value;
        public static implicit operator MaxDailyInterruptible(int value) => new MaxDailyInterruptible(value);

        public override string ToString() => Value.ToString();
    }
}