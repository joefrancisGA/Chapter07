using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class AddressTypeName : EGMSString<AddressTypeName>
    {
        protected AddressTypeName() { }

        protected AddressTypeName(string text) : base(text) { }

        public static AddressTypeName FromString(string text)
        {
            // TODO - validation - check length?  etc?

            return new AddressTypeName(text);
        }
    }
}
