using BusinessAssociates.Domain.Enums;

namespace BusinessAssociates.Domain
{
    public class CustomerAlternateFuel
    {
        public int CustomerId { get; set; }
        public AlternateFuelType AlternateFuel { get; set; }
    }
}