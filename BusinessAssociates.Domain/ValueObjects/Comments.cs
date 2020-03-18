

using BusinessAssociates.Framework;

namespace BusinessAssociates.Domain.ValueObjects
{
    public class Comments : Value<Comments>
    {
        public string Value { get; }

        private Comments(string value)
        {
            Value = value;
        }

        public static Comments Create(string comments)
        {
            return new Comments(comments);
        }

        public static implicit operator string(Comments comments)
        {
            return comments.Value;
        }

        public static explicit operator Comments(string comments)
        {
            return new Comments(comments);
        }
    }
}