using System;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class AssociateId : Value<AssociateId>
    {
        public int Value { get; }

        public AssociateId(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Associate id cannot be empty");
            
            Value = value;
        }

        public static implicit operator int(AssociateId self) => self.Value;
        public static implicit operator AssociateId(int value) => new AssociateId(value);

        public override string ToString() => Value.ToString();
    }
}