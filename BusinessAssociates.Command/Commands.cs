using System;
using System.Diagnostics.CodeAnalysis;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Domain.Enums;

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
                    public bool IsParent { get; set; }
                    public AssociateType AssociateType { get; set; }
                    public Status Status { get; set; }
                }

                public class Delete
                {
                    public int Id { get; set; }
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
                    public AssociateType AssociateType { get; set; }
                }

                public class UpdateStatus
                {
                    public int Id { get; set; }
                    public Status Status { get; set; }
                }
            }

            public static class Agent
            {

            }

            public static class Contact
            {
                public static class ContactConfiguration
                {

                }

                public static class Address
                {
                    public class Create { }
                    public class Update { }
                    public class Delete { }
                    public class UpdateAddressType { }
                    public class UpdateAddress1 { }
                    public class UpdateAddress2 { }
                    public class UpdateAddress3 { }
                    public class UpdateAddress4 { }
                    public class UpdateCity { }
                    public class UpdateGeographicState { }
                    public class UpdatePostalCode { }
                    public class UpdateCountry { }
                    public class UpdateAttention { }
                    public class UpdateComments { }
                    public class UpdateStartDate { }
                    public class UpdateEndDate { }
                    public class UpdateIsPrimary { }

                    // ReSharper disable once MemberHidesStaticFromOuterClass
                    public class UpdateIsActive { }
                }

                public class Create
                {
                }

                public class Delete
                {
                    public int Id { get; set; }
                }

                public class UpdateFirstName
                {

                }

                public class UpdateLastName
                {

                }

                public class UpdateTitle
                {

                }

                public class UpdatePrimaryPhoneId
                {

                }

                public class UpdatePrimaryEmailId
                {

                }

                public class UpdatePrimaryAddressId
                {

                }

                public class UpdateIsActive
                {

                }

                public class AddPhone
                {

                }

                public class AddEmail
                {

                }

                public class AddAddress
                {

                }
            }

            public static class Customer
            {
                public static class AlternateFuel
                {

                }
            }

            public static class EMail
            {

            }

            public static class LifecycleEvent
            {
            }

            public static class Permission
            {

            }

            public static class Phone
            {

            }

            public static class Role
            {

            }

            public static class User
            {

            }

            public static class UserContactDisplayRule
            {

            }

            #region OperatingContext

            public static class OperatingContext
            {
                public static class Address
                {


                }

                public class Create
                {
                    public int AssociateId { get; set; }
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

                public class AssociateExisting
                {

                }

                public class Update
                {

                }

                public class Delete
                {

                }
            }

            #endregion

        }
    }
}