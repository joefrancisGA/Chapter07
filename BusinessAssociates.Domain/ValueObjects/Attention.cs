

using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class Attention : Value<Attention>
    {
        public string Value { get; }

        public Attention() { }

        private Attention(string value)
        {
            Value = value;
        }

        public static Attention Create(string attention)
        {
            return new Attention(attention);
        }

        public static implicit operator string(Attention attention)
        {
            return attention.Value;
        }

        public static explicit operator Attention(string attention)
        {
            return new Attention(attention);
        }
    }
}