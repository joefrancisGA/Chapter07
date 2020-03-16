using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessAssociates.InternalAssociate
{
    public static class QueryModels
    {
        public class GetInternalAssociates
        {
            public long InternalAssociateId { get; set; }
            public int Page { get; set; }
            public int PageSize { get; set; }
        }
    }
}
