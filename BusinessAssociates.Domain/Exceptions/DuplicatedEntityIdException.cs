using System;

namespace EGMS.BusinessAssociates.Domain.Exceptions
{
    public class DuplicatedEntityIdException : Exception
    {
        public DuplicatedEntityIdException(string message)
            : base(message)
        {
        }
    }
}