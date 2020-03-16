namespace BusinessAssociates.Domain
{
    public interface IInternalAssociateRepository
    {
        InternalAssociate Load(AssociateId id);

        void Add(InternalAssociate entity);
        
        bool Exists(AssociateId id);
    }
}