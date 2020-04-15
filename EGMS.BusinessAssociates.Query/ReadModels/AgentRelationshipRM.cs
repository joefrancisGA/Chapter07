using System;

namespace EGMS.BusinessAssociates.Query.ReadModels
{
    public class AgentRelationshipRM
    {
        public int Id { get; set; }

        public int PrincipalId { get; set; }
        public int AgentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}