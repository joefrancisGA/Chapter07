using System;
using BusinessAssociates.Framework;

namespace BusinessAssociates.Domain
{
    public class AssociateId : Value<AssociateId>
    {
        public long Value { get; }

        public AssociateId(long value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "InternalAssociate id cannot be empty");
            
            Value = value;
        }

        public static implicit operator long(AssociateId self) => self.Value;
        
        public static implicit operator AssociateId(long value) 
            => new AssociateId(value);

        public override string ToString() => Value.ToString();
    }
}