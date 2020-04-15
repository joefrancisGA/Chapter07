using System;

namespace EGMS.BusinessAssociates.Query.ReadModels
{
    public class CustomerRM
    {
        public int Id { get; set; }

        public int CustomerTypeId { get; set; }
        public int DeliveryTypeId { get; set; }
        public int DUNSNumber { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public int BasicPoolId { get; set; }
        public int StatusCodeId { get; set; }
        public int LDCId { get; set; }
        public string AccountNumber { get; set; }
        public int LossTierId { get; set; }
        public int DeliveryLocation { get; set; }
        public int ShipperId { get; set; }
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
        public int CurrentDemand { get; set; }
        public int PreviousDemand { get; set; }
        public int NominationLevelId { get; set; }
        public int GroupTypeId { get; set; }
        public int BalancingLevelId { get; set; }
        public string NAICSCode { get; set; }
        public string SICCode { get; set; }
        public int SICCodePercentage { get; set; }
        public int AlternateCustomerId { get; set; }
        public DateTime ShippersLetterFromDate { get; set; }
        public DateTime ShippersLetterToDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool SS1 { get; set; }
        public bool IsFederal { get; set; }
        public DateTime TurnOnDate { get; set; }
        public DateTime TurnOffDate { get; set; }
    }
}