using System.Threading.Tasks;


namespace EGMS.BusinessAssociates.Domain.Repositories
{
    public interface IAssociateRepository
    {
        Task<Associate> Load(int id);

        void Add(Associate entity);

        // No delete for Associates
        //void Delete(Associate entity);
        
        bool Exists(int id);

        void AddOperatingContext(int id, OperatingContext operatingContext);
    }
}