using System;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class CurrentDemand : Value<CurrentDemand>
    {
        public int Value { get; }

        public CurrentDemand() { }

        public CurrentDemand(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Current demand cannot be empty");
            
            Value = value;
        }

        public static implicit operator int(CurrentDemand self) => self.Value;
        public static implicit operator CurrentDemand(int value) => new CurrentDemand(value);

        public override string ToString() => Value.ToString();
    }
}