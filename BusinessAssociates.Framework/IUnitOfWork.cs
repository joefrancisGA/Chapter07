using System.Threading.Tasks;

namespace BusinessAssociates.Framework
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}