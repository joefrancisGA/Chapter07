

using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class PermissionName : Value<PermissionName>
    {
        public string Value { get; }

        public PermissionName() { }

        private PermissionName(string value)
        {
            Value = value;
        }

        public static PermissionName Create(string permissionName)
        {
            return new PermissionName(permissionName);
        }

        public static implicit operator string(PermissionName permissionName)
        {
            return permissionName.Value;
        }

        public static explicit operator PermissionName(string permissionName)
        {
            return new PermissionName(permissionName);
        }
    }
}