using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Customer : Entity<DatabaseId>
    {
        public Customer(Action<object> applier) : base(applier) { }

        public CustomerTypeLookup CustomerType { get; set; }
        public DeliveryTypeLookup DeliveryType { get; set; }
        public DUNSNumber DUNSNumber { get; set; }
        public LongName LongName { get; set; }
        public DatabaseId BasicPoolId { get; set; }
        public StatusCodeLookup Status { get; set; }
        public DatabaseId LDCId { get; set; }
        public AccountNumber AccountNumber { get; set; }

        public LossTierTypeLookup LossTier { get; set; }
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
        public NominationLevelTypeLookup NominationLevel { get; set; }
        public GroupTypeLookup GroupType { get; set; }
        public BalancingLevelTypeLookup BalancingLevel { get; set; }
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

        public List<AssociateCustomer> AssociateCustomers { get; set; }


        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}