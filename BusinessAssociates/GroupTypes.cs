using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class GroupTypes
    {
        public GroupTypes()
        {
            Customers = new HashSet<Customers>();
        }

        public int Id { get; set; }
        public string GroupTypeName { get; set; }
        public string GroupTypeDescription { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
