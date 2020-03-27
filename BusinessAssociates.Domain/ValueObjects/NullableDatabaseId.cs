using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class NullableDatabaseId : Value<NullableDatabaseId>
    {
        public int? Value { get; }

        public NullableDatabaseId() { }

        public NullableDatabaseId(int?value)
        {
            Value = value;
        }

        public static implicit operator int?(NullableDatabaseId self) => self.Value;
        public static implicit operator NullableDatabaseId(int value) => new NullableDatabaseId(value);

        public override string ToString() => Value.ToString();
    }
}