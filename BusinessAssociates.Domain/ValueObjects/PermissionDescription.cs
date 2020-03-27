

using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class PermissionDescription : Value<PermissionDescription>
    {
        public string Value { get; }

        public PermissionDescription() { }

        private PermissionDescription(string value)
        {
            Value = value;
        }

        public static PermissionDescription Create(string permissionDescription)
        {
            return new PermissionDescription(permissionDescription);
        }

        public static implicit operator string(PermissionDescription permissionDescription)
        {
            return permissionDescription.Value;
        }

        public static explicit operator PermissionDescription(string permissionDescription)
        {
            return new PermissionDescription(permissionDescription);
        }
    }
}