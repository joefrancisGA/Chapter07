using BusinessAssociates.Framework;

namespace BusinessAssociates.Domain.ValueObjects
{
    public class InternalAssociateId : Value<InternalAssociateId>
    { 
        public long Value { get; }

        public InternalAssociateId(long value)
        {
            Value = value;
        }

        public static implicit operator long(InternalAssociateId self) => self.Value;

        public static implicit operator InternalAssociateId(long value)
            => new InternalAssociateId(value);

        public override string ToString() => Value.ToString();
    }
}