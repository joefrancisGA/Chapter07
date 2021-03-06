﻿using System.Threading.Tasks;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Data.EF.NOTInMemory
{
    public class AssociateUnitOfWorkEF : IUnitOfWork
    {
        private readonly BusinessAssociatesContext _context;

        public AssociateUnitOfWorkEF(BusinessAssociatesContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
