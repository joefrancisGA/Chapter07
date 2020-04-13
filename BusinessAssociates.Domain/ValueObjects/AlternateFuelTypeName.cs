using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class AlternateFuelTypeName : EGMSString<AlternateFuelTypeName>
    {
        protected AlternateFuelTypeName() { }

        protected AlternateFuelTypeName(string text) : base(text) { }

        public static AlternateFuelTypeName FromString(string text)
        {
            // TODO - validation - check length?  etc?

            return new AlternateFuelTypeName(text);
        }
    }
}
