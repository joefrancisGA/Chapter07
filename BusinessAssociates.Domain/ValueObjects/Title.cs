

using BusinessAssociates.Framework;

namespace BusinessAssociates.Domain.ValueObjects
{
    public class Title : Value<Title>
    {
        public string Value { get; }

        private Title(string value)
        {
            Value = value;
        }

        public static Title Create(string title)
        {
            return new Title(title);
        }

        public static implicit operator string(Title title)
        {
            return title.Value;
        }

        public static explicit operator Title(string title)
        {
            return new Title(title);
        }
    }
}