

using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class AddressLine : Value<AddressLine>
    {
        public string Value { get; }

        public AddressLine() { }

        private AddressLine(string value)
        {
            Value = value;
        }

        public static AddressLine Create(string addressLine)
        {
            return new AddressLine(addressLine);
        }

        public static implicit operator string(AddressLine addressLine)
        {
            return addressLine.Value;
        }

        public static explicit operator AddressLine(string addressLine)
        {
            return new AddressLine(addressLine);
        }
    }
}