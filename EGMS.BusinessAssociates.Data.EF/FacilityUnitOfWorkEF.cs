using System.Threading.Tasks;
using EGMS.BusinessAssociates.Framework;
using EGMS.Facilities.Data.EF;

namespace EGMS.BusinessAssociates.Data.EF
{
    public class AssociateUnitOfWorkEF : IUnitOfWork
    {
        private readonly AssociatesContext _context;

        public AssociateUnitOfWorkEF(AssociatesContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
