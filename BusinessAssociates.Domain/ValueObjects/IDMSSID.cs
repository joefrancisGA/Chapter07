

using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class IDMSSID : Value<IDMSSID>
    {
        public string Value { get; }

        private IDMSSID(string value)
        {
            Value = value;
        }

        public static IDMSSID Create(string idmssid)
        {
            return new IDMSSID(idmssid);
        }

        public static implicit operator string(IDMSSID idmssid)
        {
            return idmssid.Value;
        }

        public static explicit operator IDMSSID(string idmssid)
        {
            return new IDMSSID(idmssid);
        }
    }
}