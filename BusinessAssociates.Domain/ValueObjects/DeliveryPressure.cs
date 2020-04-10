using System;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class DeliveryPressure : Value<DeliveryPressure>
    {
        public int Value { get; }

        public DeliveryPressure() { }

        public DeliveryPressure(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Delivery pressure cannot be empty");
            
            Value = value;
        }

        public static implicit operator int(DeliveryPressure self) => self.Value;
        public static implicit operator DeliveryPressure(int value) => new DeliveryPressure(value);

        public override string ToString() => Value.ToString();
    }
}