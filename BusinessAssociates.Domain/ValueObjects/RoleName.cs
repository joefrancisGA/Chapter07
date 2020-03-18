﻿

using BusinessAssociates.Framework;

namespace BusinessAssociates.Domain.ValueObjects
{
    public class RoleName : Value<RoleName>
    {
        public string Value { get; }

        private RoleName(string value)
        {
            Value = value;
        }

        public static RoleName Create(string roleName)
        {
            return new RoleName(roleName);
        }

        public static implicit operator string(RoleName roleName)
        {
            return roleName.Value;
        }

        public static explicit operator RoleName(string roleName)
        {
            return new RoleName(roleName);
        }
    }
}