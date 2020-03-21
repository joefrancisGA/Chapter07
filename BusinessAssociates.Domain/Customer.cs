using System;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Customer : Entity<DatabaseId>
    {
        public CustomerType CustomerType { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public DUNSNumber DUNSNumber { get; set; }
        public LongName LongName { get; set; }
        public DatabaseId BasicPoolId { get; set; }
        public Status Status { get; set; }
        public DatabaseId LDCId { get; set; }
        public AccountNumber AccountNumber { get; set; }

        public LossTierType LossTier { get; set; }
        public DatabaseId DeliveryLocation { get; set; }
        public DatabaseId ShipperId { get; set; }
        public DeliveryPressure DeliveryPressure { get; set; }
        public DatabaseId ContractTypeId { get; set; }
        public MDQ MDQ { get; set; }
        public MaxHourlyInterruptible MaxHourlyInterruptible { get; set; }
        public MaxDailyInterruptible MaxDailyInterruptible { get; set; }
        public MaxHourlySpecifiedFirm MaxHourlySpecifiedFirm { get; set; }
        public HourlyInterruptible HourlyInterruptible { get; set; }
        public DailyInterruptible DailyInterruptible { get; set; }
        public TotalHourlySpecifiedFirm TotalHourlySpecifiedFirm { get; set; }
        public TotalDailySpecifiedFirm TotalDailySpecifiedFirm { get; set; }
        public InterstateSpecifiedFirm InterstateSpecifiedFirm { get; set; }
        public IntrastateSpecifiedFirm IntrastateSpecifiedFirm { get; set; }
        public CurrentDemand CurrentDemand { get; set; }
        public PreviousDemand PreviousDemand { get; set;}
        public NominationLevel NominationLevel { get; set; }
        public GroupType GroupType { get; set; }
        public BalancingLevel BalancingLevel { get; set; }
        public NAICSCode NAICSCode { get; set; }
        public SICCode SICCode { get; set; }
        public SICCodePercentage SICCodePercentage { get; set; }
        public DatabaseId AlternateCustomerId { get; set; }

        public DateTime ShippersLetterFromDate { get; set; }
        public DateTime ShippersLetterToDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool SS1 { get; set; }
        public bool IsFederal { get; set; }
        public DateTime TurnOnDate { get; set; }
        public DateTime TurnOffDate { get; set; }

        public Customer(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}