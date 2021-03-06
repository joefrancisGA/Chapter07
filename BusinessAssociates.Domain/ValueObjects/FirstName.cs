﻿

using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class FirstName : Value<FirstName>
    {
        public string Value { get; }

        public FirstName() { }

        private FirstName(string value)
        {
            Value = value;
        }

        public static FirstName Create(string firstName)
        {
            return new FirstName(firstName);
        }

        public static implicit operator string(FirstName firstName)
        {
            return firstName.Value;
        }

        public static explicit operator FirstName(string firstName)
        {
            return new FirstName(firstName);
        }
    }
}