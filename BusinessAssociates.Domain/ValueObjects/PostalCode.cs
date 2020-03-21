

using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class PostalCode : Value<City>
    {
        public string Value { get; }

        private PostalCode(string value)
        {
            Value = value;
        }

        public static PostalCode Create(string postalCode)
        {
            return new PostalCode(postalCode);
        }

        public static implicit operator string(PostalCode postalCode)
        {
            return postalCode.Value;
        }

        public static explicit operator PostalCode(string postalCode)
        {
            return new PostalCode(postalCode);
        }
    }
}