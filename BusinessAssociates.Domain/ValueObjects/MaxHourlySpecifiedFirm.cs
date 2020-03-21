using System;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class MaxHourlySpecifiedFirm : Value<MaxHourlySpecifiedFirm>
    {
        public int Value { get; }

        public MaxHourlySpecifiedFirm(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Max Hourly Specified Firm cannot be empty");
            
            Value = value;
        }

        public static implicit operator int(MaxHourlySpecifiedFirm self) => self.Value;
        public static implicit operator MaxHourlySpecifiedFirm(int value) => new MaxHourlySpecifiedFirm(value);

        public override string ToString() => Value.ToString();
    }
}