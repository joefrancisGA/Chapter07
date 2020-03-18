﻿using System;
using BusinessAssociates.Framework;


namespace BusinessAssociates.Domain.ValueObjects
{
    public class InterstateSpecifiedFirm : Value<InterstateSpecifiedFirm>
    {
        public int Value { get; }

        public InterstateSpecifiedFirm(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Interstate Specified Firm cannot be empty");
            
            Value = value;
        }

        public static implicit operator int(InterstateSpecifiedFirm self) => self.Value;
        public static implicit operator InterstateSpecifiedFirm(int value) => new InterstateSpecifiedFirm(value);

        public override string ToString() => Value.ToString();
    }
}