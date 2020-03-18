using BusinessAssociates.Framework;

namespace BusinessAssociates.Domain.ValueObjects
{
    public class InternalAssociateId : Value<InternalAssociateId>
    { 
        public int Value { get; }

        public InternalAssociateId(int value)
        {
            Value = value;
        }

        public static implicit operator int(InternalAssociateId self) => self.Value;
        public static implicit operator InternalAssociateId(int value) => new InternalAssociateId(value);

        public override string ToString() => Value.ToString();
    }
}