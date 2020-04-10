using System;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class TotalDailySpecifiedFirm : Value<TotalDailySpecifiedFirm>
    {
        public int Value { get; }

        public TotalDailySpecifiedFirm() { }
        
        public TotalDailySpecifiedFirm(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Total Daily Specified Firm cannot be empty");
            
            Value = value;
        }

        public static implicit operator int(TotalDailySpecifiedFirm self) => self.Value;
        public static implicit operator TotalDailySpecifiedFirm(int value) => new TotalDailySpecifiedFirm(value);

        public override string ToString() => Value.ToString();
    }
}