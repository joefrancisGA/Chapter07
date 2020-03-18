using System.Collections.Generic;
using BusinessAssociates.Domain.Enums;
using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class Agent : ExternalAssociate
    {
        public Agent(DUNSNumber dunsNumber, LongName longName, ShortName shortName,
            ExternalAssociateType externalBusinessAssociateType) : base(dunsNumber, longName, shortName, externalBusinessAssociateType)
        {
            DUNSNumber = dunsNumber;
            LongName = longName;
            ShortName = shortName;
            ExternalBusinessAssociateType = externalBusinessAssociateType;
        }

        public Agent() { }
    }
}