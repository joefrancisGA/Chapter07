using BusinessAssociates.Framework;

namespace BusinessAssociates.Domain.ValueObjects
{
    public class DUNSNumber : Value<DUNSNumber>
    {

        public DUNSNumber() { }

        private DUNSNumber(int value)
        {
            Value = value;
        }

        public static DUNSNumber Create(int value)
        {
            return new DUNSNumber(value);
        }

        public int Value { get; }



        public static implicit operator int(DUNSNumber dunsNumber)
        {
            return dunsNumber.Value;
        }

        public static explicit operator DUNSNumber(int dunsNumber)
        { 
            return new DUNSNumber(dunsNumber);
        }
    }
}