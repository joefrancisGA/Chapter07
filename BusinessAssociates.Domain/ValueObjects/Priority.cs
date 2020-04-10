using System;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class Priority : Value<Priority>
    {
        public int Value { get; }

        public Priority() { }

        public Priority(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Priority cannot be null");
            
            Value = value;
        }

        public static implicit operator int(Priority self) => self.Value;
        public static implicit operator Priority(int value) => new Priority(value);

        public override string ToString() => Value.ToString();
    }
}