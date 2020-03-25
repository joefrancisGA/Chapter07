using System.Threading.Tasks;
using EGMS.BusinessAssociates.Domain.ValueObjects;

namespace EGMS.BusinessAssociates.Domain.Repositories
{
    public interface IAssociateRepository
    {
        Task<Associate> Load(AssociateId id);

        void Add(Associate entity);

        void Delete(Associate entity);

        void UpdateDUNSNumber(Associate entity);

        void UpdateAssociateType(Associate entity);

        void UpdateLongName(Associate entity);

        void UpdateIsParent(Associate entity);

        void UpdateStatus(Associate entity);

        void UpdateShortName(Associate entity);
        
        bool Exists(AssociateId id);

        void AddOperatingContext(AssociateId id, OperatingContext operatingContext);
    }
}