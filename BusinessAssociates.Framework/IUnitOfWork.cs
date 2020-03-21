using System.Threading.Tasks;

namespace EGMS.BusinessAssociates.Framework
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}