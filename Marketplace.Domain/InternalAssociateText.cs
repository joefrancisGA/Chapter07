using BusinessAssociates.Framework;

namespace BusinessAssociates.Domain
{
    public class InternalAssociateText : Value<InternalAssociateText>
    {
        public string Value { get; }

        internal InternalAssociateText(string text) => Value = text;
        
        public static InternalAssociateText FromString(string text) =>
            new InternalAssociateText(text);
        
        public static implicit operator string(InternalAssociateText text) =>
            text.Value;
    }
}