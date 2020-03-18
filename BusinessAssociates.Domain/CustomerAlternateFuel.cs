using BusinessAssociates.Domain.Enums;
using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class CustomerAlternateFuel
    {
        public DatabaseId CustomerId { get; set; }
        public AlternateFuelType AlternateFuel { get; set; }
    }
}