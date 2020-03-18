using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain.Repositories
{
    public interface IInternalAssociateRepository
    {
        InternalAssociate Load(AssociateId id);

        void Add(InternalAssociate entity);

        void UpdateDUNSNumber(InternalAssociate entity);

        void UpdateInternalAssociateType(InternalAssociate entity);

        void UpdateLongName(InternalAssociate entity);

        void UpdateIsParent(InternalAssociate entity);

        void UpdateStatus(InternalAssociate entity);

        void UpdateShortName(InternalAssociate entity);
        
        bool Exists(AssociateId id);
    }
}