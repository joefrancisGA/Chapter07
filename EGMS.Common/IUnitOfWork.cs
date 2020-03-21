using System.Threading.Tasks;

namespace EGMS.Common
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
