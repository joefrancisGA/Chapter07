using System;
using BusinessAssociates.Framework;


namespace BusinessAssociates.Domain.ValueObjects
{
    public class IntrastateSpecifiedFirm : Value<IntrastateSpecifiedFirm>
    {
        public int Value { get; }

        public IntrastateSpecifiedFirm(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Intrastate Specified Firm cannot be empty");
            
            Value = value;
        }

        public static implicit operator int(IntrastateSpecifiedFirm self) => self.Value;
        public static implicit operator IntrastateSpecifiedFirm(int value) => new IntrastateSpecifiedFirm(value);

        public override string ToString() => Value.ToString();
    }
}