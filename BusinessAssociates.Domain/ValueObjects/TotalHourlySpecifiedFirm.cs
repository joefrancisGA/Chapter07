using System;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class TotalHourlySpecifiedFirm : Value<TotalHourlySpecifiedFirm>
    {
        public int Value { get; }

        public TotalHourlySpecifiedFirm(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Total Hourly Specified Firm cannot be empty");
            
            Value = value;
        }

        public static implicit operator int(TotalHourlySpecifiedFirm self) => self.Value;
        public static implicit operator TotalHourlySpecifiedFirm(int value) => new TotalHourlySpecifiedFirm(value);

        public override string ToString() => Value.ToString();
    }
}