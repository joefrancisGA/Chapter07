using System;

namespace BusinessAssociates.Domain
{
    public class CustomerAssociate
    {
        public int CustomerId { get; set; }
        public int AssociateId { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public DateTime ServiceEndDate { get; set; }
    }
}