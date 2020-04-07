using EGMS.Common.ValueTypes.EGMS.Common.ValueTypes;


namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class BalancingLevelTypeName : EGMSString<BalancingLevelTypeName>
    {
        protected BalancingLevelTypeName() { }

        protected BalancingLevelTypeName(string text) : base(text) { }

        public static BalancingLevelTypeName FromString(string text)
        {
            // TODO - validation - check length?  etc?

            return new BalancingLevelTypeName(text);
        }
    }
}
