
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class EMailAddress : Value<EMailAddress>
    {
        public string Value { get; }

        private EMailAddress(string value)
        {
            Value = value;
        }

        public static EMailAddress Create(string eMailAddress)
        {
            return new EMailAddress(eMailAddress);
        }

        public static implicit operator string(EMailAddress eMailAddress)
        {
            return eMailAddress.Value;
        }

        public static explicit operator EMailAddress(string eMailAddress)
        {
            return new EMailAddress(eMailAddress);
        }
    }
}