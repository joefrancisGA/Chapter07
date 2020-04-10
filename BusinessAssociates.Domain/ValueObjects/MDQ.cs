using System;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class MDQ : Value<MDQ>
    {
        public int Value { get; }

        public MDQ() { }

        public MDQ(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "MDQ cannot be empty");
            
            Value = value;
        }

        public static implicit operator int(MDQ self) => self.Value;
        public static implicit operator MDQ(int value) => new MDQ(value);

        public override string ToString() => Value.ToString();
    }
}