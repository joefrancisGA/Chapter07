
using BusinessAssociates.Framework;

namespace BusinessAssociates.Domain.ValueObjects
{
    public class EMailAddress : Value<EMailAddress>
    {
        public string Value { get; }

        private EMailAddress(string value)
        {
            Value = value;
        }

        public static EMailAddress Create(string EMailAddress)
        {
            return new EMailAddress(EMailAddress);
        }

        public static implicit operator string(EMailAddress EMailAddress)
        {
            return EMailAddress.Value;
        }

        public static explicit operator EMailAddress(string EMailAddress)
        {
            return new EMailAddress(EMailAddress);
        }
    }
}