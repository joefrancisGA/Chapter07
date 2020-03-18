using System.Collections.Generic;
using BusinessAssociates.Domain.Enums;
using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class AgentUser
    {
        public Associate Agent { get; set; }
        public User User { get; set; }
    }
}