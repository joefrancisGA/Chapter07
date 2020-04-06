using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class Customers
    {
        public Customers()
        {
            AssociateCustomers = new HashSet<AssociateCustomers>();
            CustomerAlternateFuels = new HashSet<CustomerAlternateFuels>();
            OperatingContextCustomers = new HashSet<OperatingContextCustomers>();
        }

        public int Id { get; set; }
        public int CustomerTypeId { get; set; }
        public int DeliveryTypeId { get; set; }
        public int Dunsnumber { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public int? BasicPoolId { get; set; }
        public int StatusCodeId { get; set; }
        public int Ldcid { get; set; }
        public string AccountNumber { get; set; }
        public DateTime? TurnOnDate { get; set; }
        public DateTime? TurnOffDate { get; set; }
        public int Siccode { get; set; }
        public int? SiccodePercentage { get; set; }
        public int? AlternateCustomerId { get; set; }
        public int? LossTierTypeId { get; set; }
        public int? DeliveryLocation { get; set; }
        public int? ShipperId { get; set; }
        public DateTime? ShippersLetterFromDate { get; set; }
        public int? DeliveryPressure { get; set; }
        public int? ContractTypeId { get; set; }
        public int? Mdq { get; set; }
        public int? MaxHourlyInterruptible { get; set; }
        public int? MaxDailyInterruptible { get; set; }
        public int? MaxHourlySpecifiedFirm { get; set; }
        public int? HourlyInterruptible { get; set; }
        public int? DailyInterruptible { get; set; }
        public int? TotalHourlySpecifiedFirm { get; set; }
        public int? TotalDailySpecifiedFirm { get; set; }
        public int? InterstateSpecifiedFirm { get; set; }
        public int? IntrastateSpecifiedFirm { get; set; }
        public DateTime? StartDate { get; set; }
        public bool? Ss1 { get; set; }
        public int? CurrentDemand { get; set; }
        public int? PreviousDemand { get; set; }
        public bool IsFederal { get; set; }
        public int Naicscode { get; set; }
        public int? NominationLevelId { get; set; }
        public int? GroupTypeId { get; set; }
        public int? BalancingLevelId { get; set; }

        public virtual BalancingLevelTypes BalancingLevel { get; set; }
        public virtual CustomerTypes CustomerType { get; set; }
        public virtual DeliveryTypes DeliveryType { get; set; }
        public virtual GroupTypes GroupType { get; set; }
        public virtual LossTierTypes LossTierType { get; set; }
        public virtual NominationLevelTypes NominationLevel { get; set; }
        public virtual Associates Shipper { get; set; }
        public virtual StatusCodes StatusCode { get; set; }
        public virtual ICollection<AssociateCustomers> AssociateCustomers { get; set; }
        public virtual ICollection<CustomerAlternateFuels> CustomerAlternateFuels { get; set; }
        public virtual ICollection<OperatingContextCustomers> OperatingContextCustomers { get; set; }
    }
}
