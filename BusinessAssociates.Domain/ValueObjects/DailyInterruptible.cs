using System;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class DailyInterruptible : Value<DailyInterruptible>
    {
        public int Value { get; }

        public DailyInterruptible(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Daily Interruptible cannot be empty");
            
            Value = value;
        }

        public static implicit operator int(DailyInterruptible self) => self.Value;
        public static implicit operator DailyInterruptible(int value) => new DailyInterruptible(value);

        public override string ToString() => Value.ToString();
    }
}