using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class AssociateUser
    {
        public AssociateId AssociateId { get; set; }
        public DatabaseId UserId { get; set; }
    }
}