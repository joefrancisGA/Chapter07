using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class AssociateTypeDesc : EGMSString<AssociateTypeDesc>
    {
        protected AssociateTypeDesc() { }

        protected AssociateTypeDesc(string text) : base(text) { }

        public static AssociateTypeDesc FromString(string text)
        {
            // TODO - validation - check length?  etc?

            return new AssociateTypeDesc(text);
        }
    }
}
