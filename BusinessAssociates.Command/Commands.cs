using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Data.SqlClient;

namespace EGMS.BusinessAssociates.Command
{
    public static class Commands
    {
        [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
        public static class V1
        {
            public static class Associate
            {
                public class Create
                {
                    public int DUNSNumber { get; set; }
                    public string LongName { get; set; }
                    public string ShortName { get; set; }
                    public bool IsInternal { get; set; }
                    public bool IsParent { get; set; }
                    public bool IsDeactivating { get; set; }
                    public int AssociateTypeId { get; set; }
                    public int StatusCodeId { get; set; }
                }

                public class UpdateDUNSNumber
                {
                    public int Id { get; set; }
                    public int DUNSNumber { get; set; }
                }

                public class UpdateLongName
                {
                    public int Id { get; set; }
                    public string LongName { get; set; }
                }

                public class UpdateShortName
                {
                    public int Id { get; set; }
                    public string ShortName { get; set; }
                }

                public class UpdateIsParent
                {
                    public int Id { get; set; }
                    public bool IsParent { get; set; }
                }

                public class UpdateAssociateType
                {
                    public int Id { get; set; }
                    public int AssociateType { get; set; }
                }

                public class UpdateStatus
                {
                    public int Id { get; set; }
                    public int Status { get; set; }
                }
            }

            public static class AgentRelationship
            {
                public class CreateForPrincipal : Create
                {
                    public CreateForPrincipal(int principalId, Create create)
                    {
                        PrincipalId = principalId;
                        AgentId = create.AgentId;
                    }

                    public int PrincipalId { get; set; }
                }

                public class Create
                {
                    public int AgentId { get; set; }
                }

                public static class User
                {
                    public class CreateForAgent : Create
                    {
                        public CreateForAgent(int agentId, Create create)
                        {
                            AgentId = agentId;
                            UserId = create.UserId;
                        }

                        public int AgentId { get; set; }
                    }

                    public class Create
                    { 
                        public int UserId { get; set; }
                    }
                }
            }


            public static class Contact
            {
                public static class ContactConfiguration
                {
                    public class CreateForContact : Create
                    {
                        public CreateForContact(int contactId, Create create)
                        {
                            ContactId = contactId;
                            FacilityId = create.FacilityId;
                            ContactTypeId = create.ContactTypeId;
                            Priority = create.Priority;
                            StatusCodeId = create.StatusCodeId;
                            StartDate = create.StartDate;
                            EndDate = create.EndDate;
                        }

                        public int ContactId { get; set; }
                    }

                    public class Create
                    {
                        public int FacilityId { get; set; }
                        public int ContactTypeId { get; set; }
                        public int Priority { get; set; }
                        public int StatusCodeId { get; set; }
                        public DateTime StartDate { get; set; }
                        public DateTime EndDate { get; set; }
                    }
                }

                public static class EMail
                {
                    public class CreateForContact : Create
                    {
                        public CreateForContact(int contactId, Create create)
                        {
                            ContactId = contactId;
                            UserId = create.UserId;
                            EMailAddressId = create.EMailAddressId;
                            IsPrimary = create.IsPrimary;
                        }
                        
                        public int ContactId { get; set; }
                    }

                    public class Create
                    {
                        public int UserId { get; set; }
                        public int EMailAddressId { get; set; }
                        public bool IsPrimary { get; set; }
                    }
                }

                public static class Phone
                {
                    public class CreateForContact : Create
                    {
                        public CreateForContact(int contactId, Create create)
                        {
                            ContactId = contactId;
                            UserId = create.UserId;
                            PhoneTypeId = create.PhoneTypeId;
                            Extension = create.Extension;
                            IsPrimary = create.IsPrimary;
                        }

                        public int ContactId { get; set; }
                    }

                    public class Create
                    {
                        public int UserId { get; set; }
                        public int PhoneTypeId { get; set; }
                        public string Extension { get; set; }
                        public bool IsPrimary { get; set; }
                    }
                }


                public static class Address
                {
                    public class CreateForContact : Create
                    {
                        public CreateForContact(int contactId, Create create)
                        {
                            ContactId = contactId;
                            AddressType = create.AddressType;
                            Address1 = create.Address1;
                            Address2 = create.Address2;
                            Address3 = create.Address3;
                            Address4 = create.Address4;
                            City = create.City;
                            GeographicState = create.GeographicState;
                            PostalCode = create.PostalCode;
                            Country = create.Country;
                            Attention = create.Attention;
                            Comments = create.Comments;
                            StartDate = create.StartDate;
                            EndDate = create.EndDate;
                            IsPrimary = create.IsPrimary;
                            IsActive = create.IsActive;
                        }

                        public int ContactId { get; set; }
                    }

                    public class Create
                    {
                        public int AddressType { get; set; }
                        public string Address1 { get; set; }
                        public string Address2 { get; set; }
                        public string Address3 { get; set; }
                        public string Address4 { get; set; }
                        public string City { get; set; }
                        public int GeographicState { get; set; }
                        public string PostalCode { get; set; }
                        public int Country { get; set; }
                        public string Attention { get; set; }
                        public string Comments { get; set; }
                        public DateTime StartDate { get; set; }
                        public DateTime EndDate { get; set; }
                        public bool IsPrimary { get; set; }
                        public bool IsActive { get; set; }
                    }

                    public class Update { }
                }

                public class CreateForAssociate : Create
                {
                    public CreateForAssociate(int associateId, Create create)
                    {
                        AssociateId = associateId;
                        FirstName = create.FirstName;
                        LastName = create.LastName;
                        Title = create.Title;
                        UserId = create.UserId;
                        PrimaryPhoneId = create.PrimaryPhoneId;
                        PrimaryEmailId = create.PrimaryEmailId;
                        PrimaryAddressId = create.PrimaryAddressId;
                        IsActive = create.IsActive;
                    }

                    public int AssociateId { get; set; }
                }

                public class Create
                {
                    public string FirstName { get; set; }
                    public string LastName { get; set; }
                    public string Title { get; set; }
                    public int UserId { get; set; }
                    public int PrimaryPhoneId { get; set; }
                    public int PrimaryEmailId { get; set; }
                    public int PrimaryAddressId { get; set; }
                    public bool IsActive { get; set; }
                }
            }

            public static class Customer
            {
                public class CreateForAssociate : Create
                {
                    public CreateForAssociate(int associateId, Create create)
                    {
                        AssociateId = associateId;

                        CustomerTypeId = create.CustomerTypeId;
                        DeliveryTypeId = create.DeliveryTypeId;
                        DUNSNumber = create.DUNSNumber;
                        LongName = create.LongName;
                        BasicPoolId = create.BasicPoolId;
                        StatusCodeId = create.StatusCodeId;
                        LDCId = create.LDCId;
                        AccountNumber = create.AccountNumber;
                        LossTierTypeId = create.LossTierTypeId;
                        DeliveryLocationId = create.DeliveryLocationId;
                        ShipperId = create.ShipperId;
                        DeliveryPressure = create.DeliveryPressure;
                        ContractTypeId = create.ContractTypeId;
                        MDQ = create.MDQ;
                        MaxHourlyInterruptible = create.MaxHourlyInterruptible;
                        MaxDailyInterruptible = create.MaxDailyInterruptible;
                        MaxHourlySpecifiedFirm = create.MaxHourlySpecifiedFirm;
                        HourlyInterruptible = create.HourlyInterruptible;
                        DailyInterruptible = create.DailyInterruptible;
                        TotalHourlySpecifiedFirm = create.TotalHourlySpecifiedFirm;
                        TotalDailySpecifiedFirm = create.TotalDailySpecifiedFirm;
                        InterstateSpecifiedFirm = create.InterstateSpecifiedFirm;
                        IntrastateSpecifiedFirm = create.IntrastateSpecifiedFirm;
                        CurrentDemand = create.CurrentDemand;
                        PreviousDemand = create.PreviousDemand;
                        NominationLevelId = create.NominationLevelId;
                        GroupTypeId = create.GroupTypeId;
                        BalancingLevelId = create.BalancingLevelId;
                        NAICSCode = create.NAICSCode;
                        SICCode = create.SICCode;
                        SICCodePercentage = create.SICCodePercentage;
                        AlternateCustomerId = create.AlternateCustomerId;
                        ShippersLetterFromDate = create.ShippersLetterFromDate;
                        ShippersLetterToDate = create.ShippersLetterToDate;
                        StartDate = create.StartDate;
                        EndDate = create.EndDate;
                        SS1 = create.SS1;
                        IsFederal = create.IsFederal;
                        TurnOnDate = create.TurnOnDate;
                        TurnOffDate = create.TurnOffDate;
                    }

                    private int AssociateId { get; set; }
                }

                public class Create
                {
                    public int CustomerTypeId { get; set; }
                    public int DeliveryTypeId { get; set; }
                    public int DUNSNumber { get; set; }
                    public string LongName { get; set; }
                    public int BasicPoolId { get; set; }
                    public int StatusCodeId { get; set; }
                    public int LDCId { get; set; }
                    public string AccountNumber { get; set; }
                    public int LossTierTypeId { get; set; }
                    public int DeliveryLocationId { get; set; }
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

                public static class AlternateFuel
                {
                    public class CreateForCustomer : Create
                    {
                        public CreateForCustomer(int customerId, Create create)
                        {
                            CustomerId = customerId;
                            AlternateFuelId = create.AlternateFuelId;
                        }

                        public int CustomerId { get; set; }
                    }

                    public class Create
                    {
                        public int AlternateFuelId { get; set; }
                    }
                }


                public static class OperatingContext
                {
                    public class CreateForCustomer : Create
                    {
                        public CreateForCustomer(int customerId, Create create)
                        {
                            CustomerId = customerId;
                            AlternateFuelId = create.AlternateFuelId;
                        }

                        public int CustomerId { get; set; }
                    }

                    public class Create
                    { 
                        public int AlternateFuelId { get; set; }
                    }
                }
            }


            public static class Permission
            {
                public class Create
                {
                    public string PermissionName { get; set; }
                    public string PermissionDescription { get; set; }
                    public bool IsActive { get; set; }
                }
            }

            public static class Role
            {
                public class Create
                {
                    public string RoleName { get; set; }
                    public string RoleDescription { get; set; }
                }
            }


            public static class RolePermission
            {
                public class Create
                {
                    public int RoleId;
                    public int PermissionId;
                }
            }


            public static class User
            {
                public class CreateForAssociate : Create
                {
                    public CreateForAssociate(int associateId, Create create)
                    {
                        AssociateId = associateId;
                        ContactId = create.ContactId;
                        IDMSSID = create.IDMSSID;
                        DepartmentCode = create.DepartmentCode;
                        IsInternal = create.IsInternal;
                        IsActive = create.IsActive;
                        HasEGMSAccess = create.HasEGMSAccess;
                        DeactivationDate = create.DeactivationDate;
                    }

                    private int AssociateId { get; set; }
                }

                public class Create
                {
                    public int ContactId { get; set; }
                    public int IDMSSID { get; set; }
                    public int DepartmentCode { get; set; }
                    public bool IsInternal { get; set; }
                    public bool IsActive { get; set; }
                    public bool HasEGMSAccess { get; set; }
                    public DateTime DeactivationDate { get; set; }
                }
            }

            // This is a read only model
            //public static class UserContactDisplayRule {}


            #region OperatingContext

            public static class OperatingContext
            {
                public static class Address
                {
                    public class CreateForOperatingContext : Create
                    {
                        public CreateForOperatingContext(int operatingContextId, Create create)
                        {
                            OperatingContextId = operatingContextId;
                            AddressType = create.AddressType;
                            Address1 = create.Address1;
                            Address2 = create.Address2;
                            Address3 = create.Address3;
                            Address4 = create.Address4;
                            City = create.City;
                            GeographicState = create.GeographicState;
                            PostalCode = create.PostalCode;
                            Country = create.Country;
                            Attention = create.Attention;
                            Comments = create.Comments;
                            StartDate = create.StartDate;
                            EndDate = create.EndDate;
                            IsPrimary = create.IsPrimary;
                            IsActive = create.IsActive;
                        }

                        public int OperatingContextId;
                    }


                    public class Create
                    {
                        public int AddressType { get; set; }
                        public string Address1 { get; set; }
                        public string Address2 { get; set; }
                        public string Address3 { get; set; }
                        public string Address4 { get; set; }
                        public string City { get; set; }
                        public int GeographicState { get; set; }
                        public string PostalCode { get; set; }
                        public int Country { get; set; }
                        public string Attention { get; set; }
                        public string Comments { get; set; }
                        public DateTime StartDate { get; set; }
                        public DateTime EndDate { get; set; }
                        public bool IsPrimary { get; set; }
                        public bool IsActive { get; set; }
                    }
                }

                public static class Certification
                {
                    public class CreateForOperatingContext : Create
                    {
                        public CreateForOperatingContext(int operatingContextId, Create create)
                        {
                            OperatingContextId = operatingContextId;
                            IsInherited = create.IsInherited;
                            CertificationStatusId = create.CertificationStatusId;
                            CertificationDateTime = create.CertificationDateTime;
                            DecertificationDateTime = create.DecertificationDateTime;
                        }

                        public int OperatingContextId { get; set; }
                    }

                    public class Create
                    {
                        public bool IsInherited { get; set; }
                        public int CertificationStatusId { get; set; }
                        public DateTime CertificationDateTime { get; set; }
                        public DateTime DecertificationDateTime { get; set; }
                    }
                }

                public static class Customer
                {
                    public class CreateForOperatingContext : Create
                    {
                        public CreateForOperatingContext(int operatingContextId, Create create)
                        {
                            OperatingContextId = operatingContextId;

                            CustomerTypeId = create.CustomerTypeId;
                            DeliveryTypeId = create.DeliveryTypeId;
                            DUNSNumber = create.DUNSNumber;
                            LongName = create.LongName;
                            BasicPoolId = create.BasicPoolId;
                            StatusCodeId = create.StatusCodeId;
                            LDCId = create.LDCId;
                            AccountNumber = create.AccountNumber;
                            LossTierTypeId = create.LossTierTypeId;
                            DeliveryLocationId = create.DeliveryLocationId;
                            ShipperId = create.ShipperId;
                            DeliveryPressure = create.DeliveryPressure;
                            ContractTypeId = create.ContractTypeId;
                            MDQ = create.MDQ;
                            MaxHourlyInterruptible = create.MaxHourlyInterruptible;
                            MaxDailyInterruptible = create.MaxDailyInterruptible;
                            MaxHourlySpecifiedFirm = create.MaxHourlySpecifiedFirm;
                            HourlyInterruptible = create.HourlyInterruptible;
                            DailyInterruptible = create.DailyInterruptible;
                            TotalHourlySpecifiedFirm = create.TotalHourlySpecifiedFirm;
                            TotalDailySpecifiedFirm = create.TotalDailySpecifiedFirm;
                            InterstateSpecifiedFirm = create.InterstateSpecifiedFirm;
                            IntrastateSpecifiedFirm = create.IntrastateSpecifiedFirm;
                            CurrentDemand = create.CurrentDemand;
                            PreviousDemand = create.PreviousDemand;
                            NominationLevelId = create.NominationLevelId;
                            GroupTypeId = create.GroupTypeId;
                            BalancingLevelId = create.BalancingLevelId;
                            NAICSCode = create.NAICSCode;
                            SICCode = create.SICCode;
                            SICCodePercentage = create.SICCodePercentage;
                            AlternateCustomerId = create.AlternateCustomerId;
                            ShippersLetterFromDate = create.ShippersLetterFromDate;
                            ShippersLetterToDate = create.ShippersLetterToDate;
                            StartDate = create.StartDate;
                            EndDate = create.EndDate;
                            SS1 = create.SS1;
                            IsFederal = create.IsFederal;
                            TurnOnDate = create.TurnOnDate;
                            TurnOffDate = create.TurnOffDate;
                        }

                        public int OperatingContextId { get; set; }
                    }


                    public class Create
                    {
                        public int CustomerTypeId { get; set; }
                        public int DeliveryTypeId { get; set; }
                        public int DUNSNumber { get; set; }
                        public string LongName { get; set; }
                        public int BasicPoolId { get; set; }
                        public int StatusCodeId { get; set; }
                        public int LDCId { get; set; }
                        public string AccountNumber { get; set; }
                        public int LossTierTypeId { get; set; }
                        public int DeliveryLocationId { get; set; }
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

                    public static class AlternateFuel
                    {
                        public class CreateForCustomer : Create
                        {
                            public CreateForCustomer(int customerId, Create create)
                            {
                                CustomerId = customerId;
                                AlternateFuelId = create.AlternateFuelId;
                            }

                            public int CustomerId { get; set; }
                        }

                        public class Create
                        {
                            public int AlternateFuelId { get; set; }
                        }
                    }
                }

                public class CreateForAssociate : Create
                {
                    public CreateForAssociate(int associateId, Create create)
                    {
                        AssociateId = associateId;
                        OperatingContextType = create.OperatingContextType;
                        FacilityId = create.FacilityId;
                        ThirdPartySupplierId = create.ThirdPartySupplierId;
                        ProviderType = create.ProviderType;
                        ActingBATypeID = create.ActingBATypeID;
                        CertificationId = create.CertificationId;
                        Status = create.Status;
                        IsDeactivating = create.IsDeactivating;
                        StartDate = create.StartDate;
                        PrimaryEmailId = create.PrimaryEmailId;
                        PrimaryPhoneId = create.PrimaryPhoneId;
                        PrimaryAddressId = create.PrimaryAddressId;
                        LegacyId = create.LegacyId;
                    }

                    public int AssociateId;
                }

                public class Create
                {
                    public int OperatingContextType { get; set; }
                    public int FacilityId { get; set; }
                    public int ThirdPartySupplierId { get; set; }
                    public int ProviderType { get; set; }
                    public int ActingBATypeID { get; set; }
                    public int? CertificationId { get; set; }
                    public int Status { get; set; }
                    public bool IsDeactivating { get; set; }
                    public DateTime StartDate { get; set; }
                    public int PrimaryEmailId { get; set; }
                    public int PrimaryPhoneId { get; set; }
                    public int PrimaryAddressId { get; set; }
                    public int LegacyId { get; set; }
                }

                public class Update
                {

                }
            }

            #endregion
        }
    }
}