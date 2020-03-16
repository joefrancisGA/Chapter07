using System.Threading.Tasks;

namespace BusinessAssociates.Framework
{
    public interface IApplicationService
    {
        Task Handle(object command);
    }
}