using System.Threading.Tasks;

namespace EGMS.Common
{
    public interface IApplicationService
    {
        Task Handle(object command);
    }
}
