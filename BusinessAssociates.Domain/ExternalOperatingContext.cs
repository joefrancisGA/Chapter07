using System.Collections.Generic;
using BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociate.Domain;

namespace BusinessAssociates.Domain
{
    public class ExternalOperatingContext : ActingBAOperatingContext
    {
        public ExternalOperatingContext()
        {
            Status = Status.PENDING;
        }

        public ExternalOperatingContext(ProviderType providerType)
        {
            ProviderType = providerType;
        }


        public new long Id { get; set; }
        public List<AgentRelationship> AgentRelationships { get; set; }
    }
}