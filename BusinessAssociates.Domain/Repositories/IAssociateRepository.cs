using System.Threading.Tasks;


namespace EGMS.BusinessAssociates.Domain.Repositories
{
    public interface IAssociateRepository
    {
        Task<Associate> Load(int id);

        void Add(Associate entity);

        // No delete for Associate
        //void Delete(Associate entity);
        
        bool Exists(int id);

        void AddOperatingContext(OperatingContext operatingContext);
        void AddAssociateOperatingContext(Associate associate, OperatingContext operatingContext);

        void AddContactForAssociate(Associate associate, Contact contact);
    }
}