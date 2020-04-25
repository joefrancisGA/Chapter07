using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using AutoMapper;
using EGMS.BusinessAssociates.Command;
using EGMS.BusinessAssociates.Data.EF;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Query.ReadModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;

namespace EFTest
{
    class Program
    {
        private static int _instanceType;

        static void Main()
        {
            Console.WriteLine("1 = Direct Test");
            Console.WriteLine("2 = REST Test");
            string input = Console.ReadLine();


            if (!int.TryParse(input, out var testType) || testType < 1 || testType > 2)
            {
                throw new Exception("Must choose 1 or 2 for test type");
            }

            Console.WriteLine("1 = Debugger on HTTPS port 44396");
            Console.WriteLine("2 = Standalone on HTTP port 5000");

            input = Console.ReadLine();
            
            if (!int.TryParse(input, out _instanceType) || _instanceType < 1 || _instanceType > 2)
            {
                throw new Exception("Must choose 1 or 2 for test type");
            }

            DirectTest(testType);
        }

        static void DirectTest(int testType)
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

            AssociateRM associateRM;

            if (testType == 1)
                associateRM = (AssociateRM)appService.Handle(createAssociateCommand).Result;
            else
                associateRM = CreateAssociateWithREST(createAssociateCommand);

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

            ContactRM contactRM;

            if (testType == 1)
                contactRM = (ContactRM) appService.Handle(createContactForAssociateCommand).Result;
            else
                contactRM = CreateContactForAssociateWithREST(createContactForAssociateCommand);

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

            UserRM userRM;

            if (testType == 1)
                userRM = (UserRM)appService.Handle(createUserForAssociateCommand).Result;
            else
                userRM = CreateUserForAssociateWithREST(createUserForAssociateCommand);
            
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

            // ReSharper disable once NotAccessedVariable
            CustomerRM customerRM;

            if (testType == 1)
                // ReSharper disable once RedundantAssignment
                customerRM = (CustomerRM)appService.Handle(createCustomerForAssociateCommand).Result;
            else
                // ReSharper disable once RedundantAssignment
                customerRM = CreateCustomerForAssociateWithREST(createCustomerForAssociateCommand);
            
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


            // ReSharper disable once NotAccessedVariable
            OperatingContextRM operatingContextRM;

            if (testType == 1)
                // ReSharper disable once RedundantAssignment
                operatingContextRM = (OperatingContextRM)appService.Handle(createOperatingContextForUserCommand).Result;
            else
                // ReSharper disable once RedundantAssignment
                operatingContextRM = CreateOperatingContextForUserWithREST(createOperatingContextForUserCommand);

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set up relationship between Associate and OperatingContext

            Commands.V1.OperatingContext.CreateForAssociate createOperatingContextForAssociateCommand =
                new Commands.V1.OperatingContext.CreateForAssociate(associateRM.Id, createOperatingContextCommand);
            
            Console.WriteLine("EFTEST:  Getting OperatingContextRM for Associate");

            // ReSharper disable once NotAccessedVariable
            OperatingContextRM operatingContextForAssociateRM;
            
            if (testType == 1)
                // ReSharper disable once RedundantAssignment
                operatingContextForAssociateRM = (OperatingContextRM)appService.Handle(createOperatingContextForAssociateCommand).Result;
            else
                // ReSharper disable once RedundantAssignment
                operatingContextForAssociateRM = CreateOperatingContextForAssociateWithREST(createOperatingContextForAssociateCommand);

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

            // ReSharper disable once NotAccessedVariable
            AssociateRM agentRM;
            
            if (testType == 1)
                // ReSharper disable once RedundantAssignment
                agentRM = (AssociateRM)appService.Handle(createAssociateCommandForAgent).Result;
            else
                // ReSharper disable once RedundantAssignment
                agentRM = CreateAssociateWithREST(createAssociateCommandForAgent);

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

            Console.WriteLine("EFTEST: Getting UserRM for Agent");

            // ReSharper disable once NotAccessedVariable
            UserRM userRM2;

            if (testType == 1)
                // ReSharper disable once RedundantAssignment
                userRM2 = (UserRM) appService.Handle(createUserForAgent).Result;
            else
                // ReSharper disable once RedundantAssignment
                userRM2 = CreateUserForAssociateWithREST(createUserForAgent);

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

            // ReSharper disable once NotAccessedVariable
            AssociateRM assetManagerRM;
            
            if (testType == 1)
                // ReSharper disable once RedundantAssignment
                assetManagerRM = (AssociateRM)appService.Handle(createAssetManagerForTPS).Result;
            else
                // ReSharper disable once RedundantAssignment
                assetManagerRM = CreateAssociateWithREST(createAssetManagerForTPS);

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

            // ReSharper disable once NotAccessedVariable
            AssociateRM predecessorManagerRM;
            
            if (testType == 1)
                // ReSharper disable once RedundantAssignment
                predecessorManagerRM = (AssociateRM)appService.Handle(createPredecessor).Result;
            else
                // ReSharper disable once RedundantAssignment
                predecessorManagerRM = CreateAssociateWithREST(createAssetManagerForTPS);

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set up relationship between Associate and Predecessors


            //Commands.V1.

            //appService.Handle()
        }

        private const string CreateAssociateAPI = @"/api/associate";

        private static AssociateRM CreateAssociateWithREST(Commands.V1.Associate.Create cmd)
        {
            string postREST = PostREST4(CreateAssociateAPI, JsonConvert.SerializeObject(cmd));

            return ReadModels.GetAssociateRM(postREST);
        }

        private static ContactRM CreateContactForAssociateWithREST(Commands.V1.Contact.CreateForAssociate cmd)
        {
            //Commands.V1.Contact.Create createContactCommand = new Commands.V1.Contact.Create
            //{
            //    PrimaryAddressId = 1,
            //    IsActive = true,
            //    PrimaryPhoneId = 1,
            //    LastName = "Francis",
            //    PrimaryEmailId = 1,
            //    FirstName = "Joe",
            //    Title = "Mr."
            //};

            return new ContactRM();
        }

        private static UserRM CreateUserForAssociateWithREST(Commands.V1.User.CreateForAssociate cmd)
        {
            return new UserRM();
        }

        private static CustomerRM CreateCustomerForAssociateWithREST(Commands.V1.Customer.CreateForAssociate cmd)
        {
            return new CustomerRM();
        }

        private static OperatingContextRM CreateOperatingContextForUserWithREST(Commands.V1.OperatingContext.Create cmd)
        {
            return new OperatingContextRM();
        }

        private static OperatingContextRM CreateOperatingContextForAssociateWithREST(Commands.V1.OperatingContext.CreateForAssociate cmd)
        {
            return new OperatingContextRM();
        }

        public static string PostREST4(string url, string jsonData)
        {
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            using HttpClient client = new HttpClient(clientHandler);

            string fullURL = (_instanceType == 1) ? @"https://localhost:44396" : @"http://localhost:5000" + url;

            var response = client.PostAsync(fullURL, content).Result;

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            string jsonString = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine("Response Data: " + jsonString);

            return jsonString;
        }
    }
}
