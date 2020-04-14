using System;

namespace EGMS.BusinessAssociates.Query.ReadModels
{
    public class AddressRM
    {
        public int Id { get; set; }

        public int AddressTypeId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string City { get; set; }
        public int StateCodeId { get; set; }
        public string PostalCode { get; set; }
        public int CountryCodeId { get; set; }
        public string Attention { get; set; }
        public string Comments { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }
    }
}