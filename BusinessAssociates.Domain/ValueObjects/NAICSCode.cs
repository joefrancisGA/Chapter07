using System;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class NAICSCode : Value<NAICSCode>
    {
        public int Value { get; }

        public NAICSCode() { }

        public NAICSCode(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "NAICS Code cannot be empty");
            
            Value = value;
        }

        public static implicit operator int(NAICSCode self) => self.Value;
        public static implicit operator NAICSCode(int value) => new NAICSCode(value);

        public override string ToString() => Value.ToString();
    }
}