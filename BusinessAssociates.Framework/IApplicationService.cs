using System.Threading.Tasks;

namespace EGMS.BusinessAssociates.Framework
{
    public interface IApplicationService
    {
        Task <object>Handle(object command);
    }
}