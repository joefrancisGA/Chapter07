using System;

namespace BusinessAssociates
{
    public class DuplicatedEntityIdException : Exception
    {
        public DuplicatedEntityIdException(string message)
            : base(message)
        {
        }
    }
}