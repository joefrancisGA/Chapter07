using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class AlternateFuelTypeDesc : EGMSString<AlternateFuelTypeDesc>
    {
        protected AlternateFuelTypeDesc() { }

        protected AlternateFuelTypeDesc(string text) : base(text) { }

        public static AlternateFuelTypeDesc FromString(string text)
        {
            // TODO - validation - check length?  etc?

            return new AlternateFuelTypeDesc(text);
        }
    }
}
