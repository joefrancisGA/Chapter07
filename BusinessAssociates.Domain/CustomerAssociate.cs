using System;
using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class CustomerAssociate
    {
        public DatabaseId CustomerId { get; set; }
        public DatabaseId AssociateId { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public DateTime ServiceEndDate { get; set; }
    }
}