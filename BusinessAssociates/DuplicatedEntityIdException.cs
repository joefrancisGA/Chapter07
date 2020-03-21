using System;

namespace EGMS.BusinessAssociates.API
{
    public class DuplicatedEntityIdException : Exception
    {
        public DuplicatedEntityIdException(string message)
            : base(message)
        {
        }
    }
}