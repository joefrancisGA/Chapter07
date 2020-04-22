using System;
using AutoMapper;
using EGMS.BusinessAssociates.Command;
using EGMS.BusinessAssociates.Data.EF;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Query.ReadModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace EFTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var mapperConfig = new MapperConfiguration(cfg => { cfg.CreateMap<Associate, AssociateRM>(); });

            IMapper mapper = new Mapper(mapperConfig);
            ILoggerFactory loggerFactory = new NullLoggerFactory();
            ILogger<AssociateRepositoryEF> logger = new Logger<AssociateRepositoryEF>(loggerFactory);
            BusinessAssociatesContext context = new BusinessAssociatesContext();
            AssociateRepositoryEF repository = new AssociateRepositoryEF(context, logger, mapper);
            AssociatesApplicationService appService = new AssociatesApplicationService(repository, mapper);

            // Set up Associate

            Console.WriteLine("EFTEST:  Setting up Internal Associate Atlanta Gas Light");

            Commands.V1.Associate.Create createAssociateCommand = new Commands.V1.Associate.Create
            {
                AssociateTypeId = (int)AssociateTypeLookup.AssociateTypeEnum.InternalLDCFacility,
                DUNSNumber = 123456789,
                IsDeactivating = false,
                IsInternal = true,
                IsParent = false,
                LongName = "Atlanta Gas Light",
                ShortName = "AGL",
                StatusCodeId = (int)StatusCodeLookup.StatusCodeEnum.Active
            };

            Console.WriteLine("EFTEST:  Getting AssociateRM");

            AssociateRM associateRM = (AssociateRM)appService.Handle(createAssociateCommand).Result;

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set up Contact
            Console.WriteLine("EFTEST:  Setting up Joe Francis contact");

            Commands.V1.Contact.Create createContactCommand = new Commands.V1.Contact.Create
            {
                PrimaryAddressId = 1,
                IsActive = true,
                PrimaryPhoneId = 1,
                LastName = "Francis",
                PrimaryEmailId = 1,
                FirstName = "Joe",
                Title = "Mr."
            };

            Commands.V1.Contact.CreateForAssociate createContactForAssociateCommand =
                new Commands.V1.Contact.CreateForAssociate(associateRM.Id, createContactCommand);

            Console.WriteLine("EFTEST:  Getting ContactRM");

            ContactRM contactRM = (ContactRM)appService.Handle(createContactForAssociateCommand).Result;

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set up User for Contact

            Console.WriteLine("EFTEST:  Setting up Joe Francis User from Joe Francis contact");

            Commands.V1.User.Create createUserCommand = new Commands.V1.User.Create
            {
                ContactId = contactRM.Id,
                IDMSSID = "1",
                DepartmentCodeId = 1,
                HasEGMSAccess = true,
                IsActive = true,
                IsInternal = true
            };

            Commands.V1.User.CreateForAssociate createUserForAssociateCommand =
                new Commands.V1.User.CreateForAssociate(associateRM.Id, createUserCommand);

            Console.WriteLine("EFTEST:  Getting UserRM");

            UserRM userRM = (UserRM)appService.Handle(createUserForAssociateCommand).Result;


            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set up Customer for Associate - can we get rid of this and just use relationship object

            Console.WriteLine("EFTEST:  Setting up WalMart customer for User");

            Commands.V1.Customer.Create createCustomerCommand = new Commands.V1.Customer.Create
            {
                StartDate = DateTime.Now,
                AccountNumber = "12345678",
                AlternateCustomerId = 1,
                BalancingLevelId = 1,
                BasicPoolId = 1,
                ContractTypeId = 1,
                CurrentDemand = 1,
                DUNSNumber = 123456789,
                DailyInterruptible = 1,
                DeliveryLocationId = 1,
                DeliveryPressure = 1,
                CustomerTypeId = 1,
                DeliveryTypeId = 1,
                EndDate = DateTime.Now.AddYears(10),
                IsFederal = false,
                MDQ = 1,
                GroupTypeId = 1,
                LongName = "WalMart",
                TurnOffDate = DateTime.Now.AddYears(10),
                PreviousDemand = 1,
                SS1 = false,
                NominationLevelId = 1,
                MaxHourlyInterruptible = 1,
                NAICSCode = 1245,
                MaxDailyInterruptible = 1,
                StatusCodeId = 1,
                ShipperId = 1,
                HourlyInterruptible = 1,
                LDCId = 1,
                SICCode = 1,
                InterstateSpecifiedFirm = 1,
                TotalDailySpecifiedFirm = 1,
                ShortName = "WMT",
                SICCodePercentage = 1,
                ShippersLetterToDate = DateTime.Now.AddYears(1),
                IntrastateSpecifiedFirm = 1,
                MaxHourlySpecifiedFirm = 1,
                TotalHourlySpecifiedFirm = 1,
                ShippersLetterFromDate = DateTime.Now.AddYears(-1),
                LossTierTypeId = 1,
                TurnOnDate = DateTime.Now.AddYears(-1)
            };

            Commands.V1.Customer.CreateForAssociate createCustomerForAssociateCommand =
                new Commands.V1.Customer.CreateForAssociate(associateRM.Id, createCustomerCommand);

            Console.WriteLine("EFTEST:  Getting CustomerRM");

            CustomerRM customerRM = (CustomerRM)appService.Handle(createCustomerForAssociateCommand).Result;

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set Up Operating Context

            Commands.V1.OperatingContext.Create createOperatingContextCommand =
                new Commands.V1.OperatingContext.Create
                {
                    ActingBATypeID = 1,
                    PrimaryAddressId = 1,
                    Status = 1,
                    CertificationId = 1,
                    OperatingContextType = 1,
                    IsDeactivating = false,
                    ThirdPartySupplierId = 1,
                    FacilityId = 1,
                    ProviderType = 1,
                    LegacyId = 1,
                    PrimaryPhoneId = 1,
                    PrimaryEmailId = 1,
                    StartDate = DateTime.Now
                };

            Commands.V1.OperatingContext.CreateForUser createOperatingContextForUserCommand =
                new Commands.V1.OperatingContext.CreateForUser(userRM.Id, createOperatingContextCommand);

            Console.WriteLine("EFTEST:  Getting OperatingContextRM for User");

            OperatingContextRM operatingContextRM = (OperatingContextRM)appService.Handle(createOperatingContextForUserCommand).Result;

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set up relationship between Associate and OperatingContext

            Commands.V1.OperatingContext.CreateForAssociate createOperatingContextForAssociateCommand =
                new Commands.V1.OperatingContext.CreateForAssociate(associateRM.Id, createOperatingContextCommand);
            
            Console.WriteLine("EFTEST:  Getting OperatingContextRM for Associate");

            OperatingContextRM operatingContextForAssociateRM = (OperatingContextRM)appService.Handle(createOperatingContextForAssociateCommand).Result;

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set up Associate as Agent

            // Set up Associate

            Console.WriteLine("EFTEST:  Setting up AGL Services Agent");

            Commands.V1.Associate.Create createAssociateCommandForAgent = new Commands.V1.Associate.Create
            {
                AssociateTypeId = ActingAssociateTypeLookup.ActingAssociateTypes[(int)ActingAssociateTypeLookup.ActingAssociateTypeEnum.AssetManagerProvider].ActingAssociateTypeId,
                DUNSNumber = 123456780,
                IsDeactivating = false,
                IsInternal = true,
                IsParent = false,
                LongName = "AGL Services",
                ShortName = "SCS",
                StatusCodeId = (int)StatusCodeLookup.StatusCodeEnum.Active
            };

            Console.WriteLine("EFTEST:  Getting AssociateRM for Agent");

            AssociateRM agentRM = (AssociateRM)appService.Handle(createAssociateCommandForAgent).Result;

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // AddAssociate User to Agent

            Console.WriteLine("EFTEST:  Create User for Agent");

            Commands.V1.User.Create createUserCommandForAgent = new Commands.V1.User.Create
            {
                IsActive = true,
                IsInternal = true,
                ContactId = contactRM.Id,
                HasEGMSAccess = true,
                IDMSSID = "1",
                DeactivationDate = DateTime.Now.AddYears(10),
                DepartmentCodeId = 1
            };

            Commands.V1.User.CreateForAssociate createUserForAgent =
                new Commands.V1.User.CreateForAssociate(associateRM.Id, createUserCommandForAgent);

            Console.WriteLine("EFTEST: Getting USerRM for Agent");

            UserRM userRM2 = (UserRM)appService.Handle(createUserForAgent).Result;

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set up Asset Manager for Associate for Third-Party Suppliers

            Console.WriteLine("EFTEST:  Set up third party asset manager");

            Commands.V1.Associate.Create createAssetManagerForTPS = new Commands.V1.Associate.Create
            {
                AssociateTypeId = ActingAssociateTypeLookup.ActingAssociateTypes[(int)ActingAssociateTypeLookup.ActingAssociateTypeEnum.AssetManagerProvider].ActingAssociateTypeId,
                DUNSNumber = 123456781,
                IsDeactivating = false,
                IsInternal = true,
                IsParent = false,
                LongName = "AGL Services",
                ShortName = "SCS",
                StatusCodeId = (int)StatusCodeLookup.StatusCodeEnum.Active
            };

            Console.WriteLine("EFTEST:  Get AssociateRM for third party");

            AssociateRM assetManagerRM = (AssociateRM)appService.Handle(createAssetManagerForTPS).Result;

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set up Associate as predecessor

            Console.WriteLine("EFTEST:  Set up associate as predecessor");

            Commands.V1.Associate.Create createPredecessor = new Commands.V1.Associate.Create
            {
                AssociateTypeId = (int)AssociateTypeLookup.AssociateTypeEnum.InternalLDCFacility,
                DUNSNumber = 123456782,
                IsDeactivating = false,
                IsInternal = true,
                IsParent = false,
                LongName = "AGL Services",
                ShortName = "SCS",
                StatusCodeId = (int)StatusCodeLookup.StatusCodeEnum.Active
            };

            Console.WriteLine("EFTEST:  Get PredecessorManagerRM for predecessor");
            AssociateRM predecessorManagerRM = (AssociateRM)appService.Handle(createPredecessor).Result;

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set up relationship between Associate and Predecessors


            //Commands.V1.

            //appService.Handle()
        }
    }
}
