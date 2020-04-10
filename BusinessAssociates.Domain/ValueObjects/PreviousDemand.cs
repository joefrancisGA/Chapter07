using System;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class PreviousDemand : Value<PreviousDemand>
    {
        public int Value { get; }

        public PreviousDemand() { }

        public PreviousDemand(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Previous demand cannot be empty");
            
            Value = value;
        }

        public static implicit operator int(PreviousDemand self) => self.Value;
        public static implicit operator PreviousDemand(int value) => new PreviousDemand(value);

        public override string ToString() => Value.ToString();
    }
}