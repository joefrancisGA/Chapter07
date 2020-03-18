

using BusinessAssociates.Framework;

namespace BusinessAssociates.Domain.ValueObjects
{
    public class RoleDescription : Value<RoleDescription>
    {
        public string Value { get; }

        private RoleDescription(string value)
        {
            Value = value;
        }

        public static RoleDescription Create(string roleDescription)
        {
            return new RoleDescription(roleDescription);
        }

        public static implicit operator string(RoleDescription roleDescription)
        {
            return roleDescription.Value;
        }

        public static explicit operator RoleDescription(string roleDescription)
        {
            return new RoleDescription(roleDescription);
        }
    }
}