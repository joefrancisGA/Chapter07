using System;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class DatabaseId : Value<DatabaseId>
    {
        public int Value { get; }

        public DatabaseId(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Id cannot be empty");
            
            Value = value;
        }

        public static DatabaseId FromInt(int value)
        {
            return new DatabaseId(value);
        }

        public static implicit operator int(DatabaseId self) => self.Value;
        public static implicit operator DatabaseId(int value) => new DatabaseId(value);

        public override string ToString() => Value.ToString();
    }
}