namespace BusinessAssociates.Domain.Repositories
{
    public interface IExternalAssociateRepository
    {
        ExternalAssociate Load(AssociateId id);

        void Add(ExternalAssociate entity);

        void UpdateDUNSNumber(ExternalAssociate entity);

        void UpdateInternalAssociateType(ExternalAssociate entity);

        void UpdateLongName(ExternalAssociate entity);

        void UpdateIsParent(ExternalAssociate entity);

        void UpdateStatus(ExternalAssociate entity);

        void UpdateShortName(ExternalAssociate entity);
        
        bool Exists(AssociateId id);
    }
}