using System;

namespace EGMS.Common.ValueTypes
{
    public abstract class AggregateId<T> : EGMSValue<AggregateId<T>>
//        where T : AggregateRoot
    {
        protected AggregateId(int value)
        {
            if (value == default)
                throw new ArgumentNullException(
                    nameof(value),
                    "The Id cannot be empty");

            Value = value;
        }

        public int Value { get; }

        public static implicit operator int(AggregateId<T> self) => self.Value;

        public override string ToString() => Value.ToString();
    }
}
