
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class Extension : Value<Extension>
    {
        public string Value { get; }


        public Extension() { }

        private Extension(string value)
        {
            Value = value;
        }

        public static Extension Create(string extension)
        {
            return new Extension(extension);
        }

        public static implicit operator string(Extension extension)
        {
            return extension.Value;
        }

        public static explicit operator Extension(string extension)
        {
            return new Extension(extension);
        }
    }
}