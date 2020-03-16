using System;

namespace BusinessAssociates.Domain
{
    public class UserId
    {
        private long Value { get; set; }

        public UserId(long value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "User id cannot be empty");
            
            Value = value;
        }
        
        public static implicit operator long(UserId self) => self.Value;
    }
}