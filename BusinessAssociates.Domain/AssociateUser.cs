﻿using EGMS.BusinessAssociates.Domain.ValueObjects;

namespace EGMS.BusinessAssociates.Domain
{
    public class AssociateUser
    {
        public AssociateId AssociateId { get; set; }
        public DatabaseId UserId { get; set; }
    }
}