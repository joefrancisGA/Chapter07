
using System;
using BusinessAssociates.Domain.Enums;
using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class Customer
    {
        public long Id { get; set; }

        public CustomerType CustomerType { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public DUNSNumber DUNSNumber { get; set; }
        public LongName LongName { get; set; }
        public int BasicPoolId { get; set; }
        public Status Status { get; set; }
        public int LDCId { get; set; }
        public string AccountNumber { get; set; }
        public DateTime TurnOnDate { get; set; }
        public DateTime TurnOffDate { get; set; }
        public int SICCode { get; set; }
        public int SICCodePercentage { get; set; }
        public string AlternateCustomerId { get; set; }
        public LossTierType LossTier { get; set; }
        public int DeliveryLocation { get; set; }
        public int ShipperId { get; set; }
        public DateTime ShippersLetterFromDate { get; set; }
        public DateTime ShippersLetterToDate { get; set; }
        public int DeliveryPressure { get; set; }
        public int ContractTypeId { get; set; }
        public int MDQ { get; set; }
        public int MaxHourlyInterruptible { get; set; }
        public int MaxDailyInterruptible { get; set; }
        public int MaxHourlySpecifiedFirm { get; set; }
        public int HourlyInterruptible { get; set; }
        public int DailyInterruptible { get; set; }
        public int TotalHourlySpecifiedFirm { get; set; }
        public int TotalDailySpecifiedFirm { get; set; }
        public int InterstateSpecifiedFirm { get; set; }
        public int IntrastateSpecifiedFirm { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool SS1 { get; set; }
        public int CurrentDemand { get; set; }
        public int PreviousDemand { get; set;}
        public bool IsFederal { get; set; }
        public int NAICSCode { get; set; }
        public NominationLevel NominationLevel { get; set; }
        public GroupType GroupType { get; set; }
        public BalancingLevel BalancingLevel { get; set; }
    }
}