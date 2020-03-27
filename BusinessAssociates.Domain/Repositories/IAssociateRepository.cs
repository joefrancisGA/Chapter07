using System.Threading.Tasks;


namespace EGMS.BusinessAssociates.Domain.Repositories
{
    public interface IAssociateRepository
    {
        Task<Associate> Load(int id);

        void Add(Associate entity);

        void Delete(Associate entity);

        void UpdateDUNSNumber(Associate entity);

        void UpdateAssociateType(Associate entity);

        void UpdateLongName(Associate entity);

        void UpdateIsParent(Associate entity);

        void UpdateStatus(Associate entity);

        void UpdateShortName(Associate entity);
        
        bool Exists(int id);

        void AddOperatingContext(int id, OperatingContext operatingContext);
    }
}