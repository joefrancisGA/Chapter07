using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;

namespace EGMS.BusinessAssociates.Domain
{
    public class CustomerAlternateFuel
    {
        public DatabaseId CustomerId { get; set; }
        public AlternateFuelType AlternateFuel { get; set; }
    }
}