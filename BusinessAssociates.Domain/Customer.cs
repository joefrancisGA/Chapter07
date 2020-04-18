using System;
using System.Collections.Generic;
using System.Dynamic;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Customer : Entity<int>
    {
        private Customer()
        {
            Initialize();
        }

        public Customer(Action<object> applier) : base(applier)
        {
            Initialize();
        }

        private void Initialize()
        {
            AssociateCustomers = new HashSet<AssociateCustomer>();
            CustomerAlternateFuels = new HashSet<CustomerAlternateFuel>();
            OperatingContextCustomers = new HashSet<OperatingContextCustomer>();
        }

        // TO DO:  The number of parameters here is obviously ridiculous... but is consistent with DDD
        //   principles
        public static Customer Create(int customerId, DateTime startDate, DateTime endDate, int statusCodeId, int nominationLevelId,
            AccountNumber accountNumber, int customerTypeId, int deliveryTypeId, DUNSNumber dunsNumber, LongName longName,
            ShortName shortName, DatabaseId ldcId, int lossTierId, DatabaseId deliveryLocation, int shipperId,
            DeliveryPressure deliveryPressure, MDQ mdq, MaxHourlyInterruptible maxHourlyInterruptible,
            MaxDailyInterruptible maxDailyInterruptible, HourlyInterruptible hourlyInterruptible,
            DailyInterruptible dailyInterruptible, TotalHourlySpecifiedFirm totalHourlySpecifiedFirm,
            TotalDailySpecifiedFirm totalDailySpecifiedFirm, InterstateSpecifiedFirm interstateSpecifiedFirm,
            IntrastateSpecifiedFirm intrastateSpecifiedFirm, CurrentDemand currentDemand, PreviousDemand previousDemand,
            int groupTypeId, int balancingLevelId, NAICSCode naicsCode, SICCode sicCode,
            SICCodePercentage sicCodePercentage, DateTime shippersLetterFromDate, DateTime shippersLetterToDate,
            bool ss1, bool isFederal, DateTime turnOffDate, DateTime turnOnDate)
        {
            return new Customer
            {
                Id = customerId,
                AccountNumber = accountNumber,
                AlternateCustomerId = null,
                BalancingLevelId = balancingLevelId,
                BasicPoolId = null,
                ContractTypeId = null,
                CurrentDemand = null,
                CustomerTypeId = customerTypeId,
                DailyInterruptible = dailyInterruptible,
                DeliveryLocation = deliveryLocation,
                DeliveryPressure = deliveryPressure,
                DeliveryTypeId = deliveryTypeId,
                DUNSNumber = dunsNumber,
                EndDate = endDate,
                GroupTypeId = groupTypeId,
                HourlyInterruptible = hourlyInterruptible,
                InterstateSpecifiedFirm = interstateSpecifiedFirm,
                IntrastateSpecifiedFirm = intrastateSpecifiedFirm,
                IsFederal = isFederal,
                LDCId = ldcId,
                LongName = longName,
                LossTierId = lossTierId,
                MaxDailyInterruptible = maxDailyInterruptible,
                MaxHourlyInterruptible = maxHourlyInterruptible,
                MDQ = mdq,
                NAICSCode = naicsCode,
                NominationLevelId = nominationLevelId,
                PreviousDemand = previousDemand,
                StartDate = startDate,
                StatusCodeId = statusCodeId,
                ShortName = shortName,
                ShipperId = shipperId,
                ShippersLetterFromDate = shippersLetterFromDate,
                ShippersLetterToDate = shippersLetterToDate,
                SICCode = sicCode,
                SICCodePercentage = sicCodePercentage,
                SS1 = ss1,
                TotalDailySpecifiedFirm = totalDailySpecifiedFirm,
                TotalHourlySpecifiedFirm = totalHourlySpecifiedFirm,
                TurnOffDate = turnOffDate,
                TurnOnDate = turnOnDate
            };
        }

        public CustomerTypeLookup CustomerType { get; set; }
        public int CustomerTypeId { get; set; }

        public DeliveryTypeLookup DeliveryType { get; set; }
        public int DeliveryTypeId { get; set; }

        public DUNSNumber DUNSNumber { get; set; }
        public LongName LongName { get; set; }
        public ShortName ShortName { get; set; }
        public DatabaseId BasicPoolId { get; set; }

        public StatusCodeLookup StatusCode { get; set; }
        public int StatusCodeId { get; set; }

        public DatabaseId LDCId { get; set; }
        public AccountNumber AccountNumber { get; set; }

        public LossTierTypeLookup LossTier { get; set; }
        public int LossTierId { get; set; }

        public DatabaseId DeliveryLocation { get; set; }

        public Associate Shipper { get; set; }
        public int ShipperId { get; set; }

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
        public int NominationLevelId { get; set; }

        public GroupTypeLookup GroupType { get; set; }
        public int GroupTypeId { get; set; }

        public BalancingLevelTypeLookup BalancingLevel { get; set; }
        public int BalancingLevelId { get; set; }

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

        public HashSet<AssociateCustomer> AssociateCustomers { get; set; }
        public HashSet<CustomerAlternateFuel> CustomerAlternateFuels { get; set; }
        public HashSet<OperatingContextCustomer> OperatingContextCustomers { get; set; }


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