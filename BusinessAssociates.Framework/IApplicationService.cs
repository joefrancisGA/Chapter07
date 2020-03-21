using System.Threading.Tasks;

namespace EGMS.BusinessAssociates.Framework
{
    public interface IApplicationService
    {
        Task Handle(object command);
    }
}