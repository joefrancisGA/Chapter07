using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using AutoMapper;
using EGMS.BusinessAssociates.Command;
using EGMS.BusinessAssociates.Data.EF;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Query;
using EGMS.BusinessAssociates.Query.ReadModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;

namespace EFTest
{
    // TO DO:  Add seeding

    class Program
    {
        private static int _instanceType;
        //private static int _testType;
        private static int _technologyType;
        private static int _dunsNumber = new Random().Next(100000000,900000000);
        private static IAssociateQueryRepository _queryRepo;
        private static AssociatesApplicationService _appService;

        // What about new third party supplier ID?

        #region Associate
        // Need to test internal and external
        // Need to test Marketer, Pooler, Shipper, Asset Manager
        private const string CreateAssociateAPI = @"/api/associate";
        private const string GetAssociateAPI = @"/api/associate/{associateId}";
        private const string UpdateAssociateAPI = @"/api/associate/{associateId}";
        private const string GetAssociatesAPI = @"/api/associate";

        #endregion Associate

        #region ContactForAssociate

        private const string CreateContactForAssociateAPI = @"/api/associate/{associateId}/contacts";
        private const string UpdateContactForAssociateAPI = @"/api/associate/{associateId}/contacts/{contactId}";
        private const string GetContactForAssociateAPI = @"/api/associate/{associateId}/contacts/{contactId}";
        private const string GetContactsForAssociateAPI = @"/api/associate/{associateId}/contacts";
        private const string RemoveContactForAssociateAPI = @"/api/associate/{associateId}/contacts";

        #endregion ContactForAssociate

        #region UserForAssociate

        private const string CreateUserForAssociateAPI = @"/api/associate/{associateId}/users";
        private const string UpdateUserForAssociateAPI = @"/api/associate/{associateId}/users/{userId}";
        private const string GetUserForAssociateAPI = @"/api/associate/{associateId}/users/{userId}";
        private const string GetUsersForAssociateAPI = @"/api/associate/{associateId}/users";
        private const string RemoveUserForAssociateAPI = @"/api/associate/{associateId}/users/{userId}";

        #endregion UserForAssociate

        #region CustomerForAssociate

        private const string CreateCustomerForAssociateAPI = @"/api/associate/{associateId}/customers";
        private const string UpdateCustomerForAssociateAPI = @"/api/associate/{associateId}/customers/{customerId}";
        private const string GetCustomerForAssociateAPI = @"/api/associate/{associateId}/customers/{customerId}";
        private const string GetCustomersForAssociateAPI = @"/api/associate/{associateId}/customers";
        private const string RemoveCustomerForAssociateAPI = @"/api/associate/{associateId}/customers/{customerId}";

        #endregion CustomerForAssociate

        #region OperatingContextForAssociate

        // Need to text internal and external
        private const string CreateOperatingContextForAssociateAPI = @"/api/associate/{associateId}/operatingcontexts";
        private const string GetOperatingContextForAssociateAPI = @"/api/associate/{associateId}/operatingcontexts/{operatingContextId}";
        private const string UpdateOperatingContextForAssociateAPI = @"/api/associate/{associateId}/operatingcontexts/{operatingContextId}";
        private const string GetOperatingContextsForAssociateAPI = @"/api/associate/{associateId}/operatingcontexts";
        private const string RemoveOperatingContextForAssociateAPI = @"/api/associate/{associateId}/operatingcontexts/{operationcontextid}";

        #endregion OperatingContextForAssociate

        #region OperatingContextForCustomer

        private const string CreateOperatingContextForCustomerAPI = @"/api/associate/{associateId}/customers/{customerId}/operatingcontexts";
        private const string UpdateOperatingContextForCustomerAPI = @"/api/associate/{associateId}/customers/{customerId}/operatingcontexts/{operatingContextId}";
        private const string GetOperatingContextForCustomerAPI = @"/api/associate/{associateId}/customers/{customerId}/operatingcontexts/{operatingContextId}";
        private const string GetOperatingContextsForCustomerAPI = @"/api/associate/{associateId}/customers/{customerId}/operatingcontexts";
        private const string RemoveOperatingContextForCustomerAPI = @"/api/associate/{associateId}/customers/{customerId}/operatingcontexts/{operatingcontextId}";

        #endregion OperatingContextForCustomer

        #region AddressForOperatingContext

        private const string CreateAddressForOperatingContextAPI = @"{associateId}/operatingcontexts/{operatingContextId}/Addresses";
        private const string UpdateAddressForOperatingContextAPI = @"{associateId}/operatingcontexts/{operatingContextId}/Addresses/{addressId}";
        private const string GetAddressForOperatingContextAPI = @"{associateId}/operatingcontexts/{operatingContextId}/Addresses/{addressId}";
        private const string RemoveAddressForOperatingContextAPI = @"{associateId}/operatingcontexts/{operatingContextId}/Addresses/{addressId]";
        private const string GetAddressesForOperatingContextAPI = @"{associateId}/operatingcontexts/{operatingContextId}/Addresses";

        #endregion AddressForOperatingContext

        #region AddressForContact

        private const string CreateAddressForContactAPI = @"{associateId}/contacts/{contactId}/Addresses";
        private const string UpdateAddressForContactAPI = @"{associateId}/contact/{contactId}/Addresses/{addressId}";
        private const string GetAddressForContactAPI = @"{associateId}/contact/{contactId}/Addresses/{addressId}";
        private const string RemoveAddressForContactAPI = @"{associateId}/contact/{contactId}/Addresses/{addressId}";
        private const string GetAddressesForContactAPI = @"{associateId}/contacts/{contactId}/Addresses";

        #endregion AddressForContact

        #region AgentRelationships

        private const string CreateAgentRelationshipForPrincipalAPI = @"{principalId}/agentrelationships";
        private const string GetAgentRelationshipsForPrincipalAPI = @"{principalId}/agentrelationships";
        private const string GetAgentRelationshipForPrincipalAPI = @"{principalId}/agentrelationships/{agentRelationshipId}";
        private const string UpdateAgentRelationshipForPrincipalAPI = @"{principalId}/agentrelationships/{agentRelationshipId}";
        private const string RemoveAgentRelationshipForPrincipalAPI = @"{principalId}/agentrelationships/{agentRelationshipId}";

        #endregion AgentRelationships

        #region AgentRelationshipUser

        private const string CreateUserForAgentRelationshipAPI = @"{associateId}/agentrelationships/{agentId}/Users";           // POST
        private const string GetUserForAgentRelationshipAPI = @"{associateId}/agentrelationships/{agentId}/Users";              // GET
        private const string GetUsersForAgentRelationshipAPI = @"{associateId}/agentrelationships/{agentId}/Users/{userId}";    // GET
        private const string RemoveUserFromAgentRelationshipAPI = @"{associateId}/agentrelationships/{agentId}/Users/{userId}";          // DELETE
        private const string DeleteUserFromAgentRelationshipAPI = @"{associateId}/agentrelationships/{agentId}/Users/{serId}";          // DELETE

        #endregion AgentRelationshipUser

        #region Certification

        private const string CreateCertificationForOperatingContextAPI = @"{associateId}/operatingcontexts/{operatingContextId}/Certification";
        private const string GetCertificationForOperatingContextAPI = @"{associateId}/operatingcontexts/{operatingContextId}/Certification/{certificationId}";
        private const string UpdateCertificationForOperatingContextAPI = @"{associateId}/operatingcontexts/{operatingContextId}/Certification/{certificationId}";
        private const string RemoveCertificationForOperatingContextAPI = @"{associateId}/operatingcontexts/{operatingContextId}/Certification";

        #endregion Certification

        #region ContactConfiguration

        private const string CreateContactConfigurationForContactAPI = @"{associateId}/contacts/{contactId}/ContactConfiguration";
        private const string GetContactConfigurationForContactAPI = @"{associateId}/contacts/{contactId}/ContactConfiguration/{contactConfigurationId}";
        private const string GetContactConfigurationsForContactAPI = @"{associateId}/contacts/{contactId}/ContactConfiguration";
        private const string UpdateContactConfigurationForContactAPI = @"{associateId}/contacts/{contactId}/ContactConfiguration/{configurationId}";
        private const string RemoveContactConfigurationForContactAPI = @"{associateId}/contacts/{contactId}/ContactConfiguration/{configurationId}";

        #endregion ContactConfiguration

        #region EMail

        private const string CreateEMailForAssociateAPI = @"{associateId}/contacts/{contactId}/Emails"; 
        private const string GetEMailForAssociateAPI = @"{associateId}/contacts/{contactId}/Emails/{emailId}";
        private const string GetEMailsForAssociateAPI = @"{associateId}/contacts/{contactId}/Emails";
        private const string RemoveEMailForAssociateAPI = @"{associateId}/contacts/{contactId}/Emails/{emailId}";
        private const string UpdateEMailForAssociateAPI = @"{associateId}/contacts/{contactId}/Emails/{emailId}";

        #endregion EMail

        #region Phone

        private const string CreatePhoneForContactAPI = @"{associateId}/contacts/{contactId}/Phones";
        private const string GetPhoneForContactAPI = @"{associateId}/contacts/{contactId}/Phones/{phoneId}";
        private const string GetPhonesForContactAPI = @"{associateId}/contacts/{contactId}/Phones";
        private const string UpdatePhoneForContactAPI = @"{associateId}/contacts/{contactId}/Phones/{phoneId}";
        private const string RemovePhoneForContactAPI = @"{associateId}/contacts/{contactId}/Phones/{phoneId}";

        #endregion Phone

        #region AlternateFuel

        private const string CreateAlternateFuelForCustomerAPI = @"{associateId}/customers/{customerId}/AlternateFuels/{alternateFuelId}";
        private const string RemoveAlternateFuelForCustomerAPI = @"{associateId}/customers/{customerId}/AlternateFuels/{alternateFuelId}";

        #endregion AlternateFuel

        #region CustomerForOperatingContext

        private const string CreateCustomerForOperatingContextAPI = @"{associateId}/OperatingContexts/{operatingContextId}/Customers";
        private const string GetCustomerForOperatingContextAPI = @"{associateId}/OperatingContexts/{operatingContextId}/Customers/{customerId}";
        private const string GetCustomersForOperatingContextAPI = @"{associateId}/OperatingContexts/{operatingContextId}/Customers";
        private const string UpdateCustomerForOperatingContextAPI = @"{associateId}/OperatingContexts/{operatingContextId}/Customers/{CustomerId}";
        private const string RemoveCustomerForOperatingContextAPI = @"{associateId}/OperatingContexts/{operatingContextId}/Customers/{CustomerId}";

        #endregion CustomerForOperatingContext

        #region Role

        private const string CreateRoleAPI = @"{associateId}/roles";
        private const string GetRoleAPI = @"{associateId}/roles/{roleId}";
        private const string GetRolesAPI = @"{associateId}/roles";
        private const string RemoveRoleAPI = @"{associateId}/roles/{roleId}";

        #endregion Role

        #region EGMSPermission

        private const string CreateEGMSPermissionAPI = @"{associateId}/egmspermissions";
        private const string GetEGMSPermissionAPI = @"{associateId}/egmspermission/{egmspermissionid}";
        private const string GetEGMSPermissionsAPI = @"{associateId}/egmspermissions";
        private const string RemoveEGMSPermissionAPI = @"{associateId}/egmspermissions/{egmspermissionId}";

        #endregion EGMSPermission

        #region RoleEGMSPermission

        private const string CreateRoleEGMSPermissionAPI = @"{associateId}/roleegmspermissions";
        private const string GetRoleEGMSPermissionAPI = @"{associateId}/roleegmspermissions/{roleegmspermissionid}";
        private const string GetRoleEGMSPermissionsAPI = @"{associateId}/roleegmspermissions";
        private const string RemoveRoleEGMSPermissionAPI = @"{associateId}/roleegmspermissions/{roleegmspermissionid}";

        #endregion RoleEGMSPermission


        static void Main()
        {
            Console.WriteLine("Select Technology");
            Console.WriteLine("1 = Direct");
            Console.WriteLine("2 = REST");

            string input = Console.ReadLine();


            if (!int.TryParse(input, out _technologyType) || _technologyType < 1 || _technologyType > 2)
            {
                throw new Exception("Must choose 1 or 2 for technology type");
            }

            Console.WriteLine("1 = Direct Test");
            Console.WriteLine("2 = Landing Page");
            Console.WriteLine("3 = Add Business Associate");
            Console.WriteLine("4 = Add Internal Business Associate");
            Console.WriteLine("5 = Add Internal Operating Context");
            Console.WriteLine("6 = Add Asset Manager");
            Console.WriteLine("7 = Add External Business Associate");
            Console.WriteLine("8 = Add External Operating Context");
            Console.WriteLine("9 = Add Agent");
            Console.WriteLine("10 = Add Contact");
            Console.WriteLine("11 = Add Customer");
            Console.WriteLine("12 = Add Pipeline Company");

            input = Console.ReadLine();


            if (!int.TryParse(input, out var testType) || testType < 1 || testType > 12)
            {
                throw new Exception("Must choose 1 through 12 for test type");
            }

            if (testType == 2)
            {
                Console.WriteLine("1 = Debugger on HTTPS port 44396");
                Console.WriteLine("2 = Standalone on HTTP port 5000");

                input = Console.ReadLine();

                if (!int.TryParse(input, out _instanceType) || _instanceType < 1 || _instanceType > 2)
                {
                    throw new Exception("Must choose 1 or 2 for instance type");
                }
            }

            if (_technologyType != 2)
                Initialize();

            switch (testType)
            { 
                case 1:
                    DirectTest();
                    break;

                case 2:
                    LandingPage();
                    break;

                case 3:
                    AddBusinessAssociate();
                    break;

                case 4:
                    AddInternalBusinessAssociate();
                    break;

                case 5:
                    AddInternalOperatingContext();
                    break;

                case 6:
                    AddAssetManager();
                    break;

                case 7:
                    AddExternalBusinessAssociate();
                    break;

                case 8:
                    AddExternalOperatingContext();
                    break;

                case 9:
                    AddAgent();
                    break;

                case 10:
                    AddContact();
                    break;

                case 11:
                    AddCustomer();
                    break;

                case 12:
                    AddPipelineCompany();
                    break;
            }
        }

        private static void LandingPage()
        {
            // Just need to call GetAssociates()
            List<AssociateRM> associates = GetListOfAssociates();
        }

        private static void AddBusinessAssociate()
        {
            AssociateRM agl = CreateAssociate_AtlantaGasLight();
            AddPrimaryPhoneForAssociate(agl, PhoneTypeLookup.PhoneTypeEnum.Office, 6783242548);
            AddPrimaryEMailForAssociate(agl, "x2jafran@southernco.com");
        }

        private static void AddInternalBusinessAssociate()
        {
            // Generic business associate setup first
            AssociateRM agl = CreateAssociate_AtlantaGasLight();
            PhoneRM phoneRM = AddPrimaryPhoneForAssociate(agl, PhoneTypeLookup.PhoneTypeEnum.Office, 6783242548);
            EMailRM emailRM = AddPrimaryEMailForAssociate(agl, "x2jafran@southernco.com");
            AddressRM addressRM = AddPrimaryAddressForAssociate(agl);

            // Add contact
            ContactRM contactRM = AddContactForAssociate(agl, addressRM.Id, phoneRM.Id, emailRM.Id, "Joe", "Francis");

            // Add operating context
            OperatingContextRM operatingContextRM = AddOperatingContextForAssociate(agl);
        }

        private static OperatingContextRM AddOperatingContextForAssociate(AssociateRM associateRM)
        {
            Console.WriteLine("EFTEST:  Setting up operating context for Associate " + associateRM.LongName);

            Commands.V1.OperatingContext.CreateForAssociate createOperatingContextCommand =
                new Commands.V1.OperatingContext.CreateForAssociate
                {
                    AssociateId = associateRM.Id,
                    ActingBATypeID = 1,
                    PrimaryAddressId = 1,
                    Status = 1,
                    FacilityId = associateRM.Id,
                    PrimaryPhoneId = 1,
                    OperatingContextType = (int)OperatingContextTypeLookup.OperatingContextTypeEnum.Internal,
                    IsDeactivating = false,
                    PrimaryEmailId = 1,
                    StartDate = DateTime.Now
                    };

            if (_technologyType != 1)
                throw new InvalidOperationException("AddOperatingContextForAssociate not supported for REST");

            return (OperatingContextRM)_appService.Handle(createOperatingContextCommand).Result;
        }

        private static PhoneRM AddPrimaryPhoneForAssociate(AssociateRM associateRM, PhoneTypeLookup.PhoneTypeEnum phoneType, long phoneNumber)
        {
            Console.WriteLine("EFTEST:  Setting up primary phone for Associate " + associateRM.LongName);

            Commands.V1.Associate.Phone.CreateForAssociate createPhoneCommand =
                new Commands.V1.Associate.Phone.CreateForAssociate
                {
                    AssociateId = associateRM.Id,
                    IsPrimary = true,
                    Extension = null,
                    PhoneTypeId = (int) phoneType,
                    PhoneNumber = phoneNumber
                };

            if (_technologyType != 1)
                throw new InvalidOperationException("AddPrimaryPhoneForAssociate not supported for REST");

            return (PhoneRM) _appService.Handle(createPhoneCommand).Result;
        }

        private static EMailRM AddPrimaryEMailForAssociate(AssociateRM associateRM, string eMailAddress)
        {
            Console.WriteLine("EFTEST:  Setting up primary email for Associate " + associateRM.LongName);

            Commands.V1.Associate.EMail.CreateForAssociate createEMailCommand =
                new Commands.V1.Associate.EMail.CreateForAssociate
                {
                    AssociateId = associateRM.Id,
                    EMailAddress = eMailAddress,
                    IsPrimary = true
                };

            if (_technologyType != 1)
                throw new InvalidOperationException("AddPrimaryEMailForAssociate not supported for REST");

            return (EMailRM)_appService.Handle(createEMailCommand).Result;
        }

        private static AddressRM AddPrimaryAddressForAssociate(AssociateRM associateRM)
        {
            Console.WriteLine("EFTEST:  Setting up primary address for Associate " + associateRM.LongName);

            Commands.V1.Associate.Address.CreateForAssociate createAddressCommand =
                new Commands.V1.Associate.Address.CreateForAssociate
                {
                    AssociateId = associateRM.Id,
                    AddressType = (int)AddressTypeLookup.AddressTypeEnum.Physical,
                    Address1 = "401 Bloombridge Way",
                    City = "Marietta",
                    GeographicState = 1,
                    PostalCode = "30066",
                    Country = 1,
                    StartDate = DateTime.Now.Date,
                    IsPrimary = true,
                    IsActive = true
                };

            if (_technologyType != 1)
                throw new InvalidOperationException("AddPrimaryAddressForAssociate not supported for REST");

            return (AddressRM)_appService.Handle(createAddressCommand).Result;
        }

        private static ContactRM AddContactForAssociate(AssociateRM associateRM, int primaryAddressId, int primaryPhoneId, 
            int primaryEMailId, string firstName, string lastName)
        {
            Console.WriteLine("EFTEST:  Adding contact for Associate " + associateRM.LongName);

            Commands.V1.Contact.CreateForAssociate createContactCommand =
                new Commands.V1.Contact.CreateForAssociate
                {
                    PrimaryAddressId = primaryAddressId,
                    IsActive = true,
                    PrimaryPhoneId = primaryPhoneId,
                    LastName = lastName,
                    PrimaryEmailId = primaryEMailId,
                    FirstName = firstName,
                    Title = "Mr."
                };

            if (_technologyType != 1)
                throw new InvalidOperationException("AddContactForAssociate not supported for REST");

            return (ContactRM)_appService.Handle(createContactCommand).Result;
        }


        private static void AddInternalOperatingContext()
        {
            throw new NotImplementedException();
        }

        private static void AddAssetManager()
        {
            throw new NotImplementedException();
        }

        private static void AddExternalBusinessAssociate()
        {
            throw new NotImplementedException();
        }

        private static void AddExternalOperatingContext()
        {
            throw new NotImplementedException();
        }

        private static void AddAgent()
        {
            throw new NotImplementedException();
        }

        private static void AddContact()
        {
            throw new NotImplementedException();
        }

        private static void AddCustomer()
        {
            throw new NotImplementedException();
        }

        private static void AddPipelineCompany()
        {
            throw new NotImplementedException();
        }


        static void Initialize()
        {
            var mapperConfig = new MapperConfiguration(cfg => { cfg.CreateMap<Associate, AssociateRM>(); });

            IMapper mapper = new Mapper(mapperConfig);
            ILoggerFactory loggerFactory = new NullLoggerFactory();
            ILogger<AssociateRepositoryEF> logger = new Logger<AssociateRepositoryEF>(loggerFactory);

            DbContextOptionsBuilder<BusinessAssociatesContext> optionsBuilder =
                new DbContextOptionsBuilder<BusinessAssociatesContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\egms;Database=BusinessAssociates;Trusted_Connection=True").EnableSensitiveDataLogging();

            BusinessAssociatesContext context = new BusinessAssociatesContext(optionsBuilder.Options);
            AssociateRepositoryEF repository = new AssociateRepositoryEF(context, logger, mapper);
            _appService = new AssociatesApplicationService(repository, mapper);
            _queryRepo = new AssociateQueryRepositoryEF(context, mapper);
        }

        static void DirectTest()
        {

            AssociateRM associateRM = CreateAssociate_AtlantaGasLight();
            IEnumerable<AssociateRM> associates = GetListOfAssociates();
            ContactRM contactRM = CreateContact_JoeFrancis(associateRM);
            UserRM userRM = CreateUserForContact(associateRM, contactRM);
            CustomerRM customerRM = CreateCustomer_WalMart(associateRM);
            OperatingContextRM operatingContextRM = GetOperatingContext(customerRM);
            OperatingContextRM operatingContextForAssociateRM = GetOperatingContextForAssociate(associateRM);
            SetUpAGLServicesAgent();
            CreateUserForAgent(contactRM, associateRM);
            AssociateRM assetManagerRM = SetUpThirdPartyAssetManager();
            SetUpAssociateAsPredecessor();
        }

        #region REST Methods

        private static AssociateRM CreateAssociateWithREST(Commands.V1.Associate.Create cmd)
        {
            string postREST = PostREST(CreateAssociateAPI, JsonConvert.SerializeObject(cmd));

            return ReadModels.GetAssociateRM(postREST);
        }

        private static ContactRM CreateContactForAssociateWithREST(int associateId, Commands.V1.Contact.Create cmd)
        {
            string url = CreateContactForAssociateAPI.Replace("{associateId}", associateId.ToString());
            string postREST = PostREST(url, JsonConvert.SerializeObject(cmd));

            return ReadModels.GetContactRM(postREST);
        }

        private static UserRM CreateUserForAssociateWithREST(Commands.V1.User.CreateForAssociate cmd)
        {
            string url = CreateUserForAssociateAPI.Replace("{associateId}", cmd.AssociateId.ToString());
            string postREST = PostREST(url, JsonConvert.SerializeObject(cmd));

            return ReadModels.GetUserRM(postREST);
        }

        private static CustomerRM CreateCustomerForAssociateWithREST(Commands.V1.Customer.CreateForAssociate cmd)
        {
            string url = CreateCustomerForAssociateAPI.Replace("{associateId}", cmd.AssociateId.ToString());
            string postREST = PostREST(url, JsonConvert.SerializeObject(cmd));

            return ReadModels.GetCustomerRM(postREST);
        }

        private static OperatingContextRM CreateOperatingContextForCustomerWithREST(Commands.V1.OperatingContext.CreateForCustomer cmd)
        {
            string url = CreateOperatingContextForCustomerAPI.Replace("{customerId}", cmd.CustomerId.ToString());

            // The associate Id is not really important, but perhaps it should be
            url = url.Replace("{associateId}", "1");

            string postREST = PostREST(url, JsonConvert.SerializeObject(cmd));

            return ReadModels.GetOperatingContextRM(postREST);
        }

        private static OperatingContextRM CreateOperatingContextForAssociateWithREST(int associateId, Commands.V1.OperatingContext.Create cmd)
        {
            string url = CreateOperatingContextForAssociateAPI.Replace("{associateId}", associateId.ToString());

            string postREST = PostREST(url, JsonConvert.SerializeObject(cmd));

            return ReadModels.GetOperatingContextRM(postREST);
        }

        #endregion REST Methods

        #region Creation Helpers

        public static string PostREST(string url, string jsonData)
        {
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            Console.WriteLine("Request Data: " + jsonData);

            using HttpClient client = new HttpClient(clientHandler);

            string fullURL = (_instanceType == 1 ? @"https://localhost:44396" : @"http://localhost:5000") + url;

            Console.WriteLine("Full URL = " + fullURL);

            var response = client.PostAsync(fullURL, content).Result;

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }

            string jsonString = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine("Response Data: " + jsonString);

            return jsonString;
        }

        public static string GetREST(string url)
        {
            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            using HttpClient client = new HttpClient(clientHandler);

            string fullURL = (_instanceType == 1 ? @"https://localhost:44396" : @"http://localhost:5000") + url;

            Console.WriteLine("Full URL = " + fullURL);

            var response = client.GetAsync(fullURL).Result;

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }

            string jsonString = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine("Response Data: " + jsonString);

            return jsonString;
        }

        #endregion Creation Helpers

        #region Query Methods

        private static List<AssociateRM> GetListOfAssociates()
        {
            Console.WriteLine("EFTEST:  Get list of associates");

            List<AssociateRM> associates = (_technologyType == 1 ? _queryRepo.GetAssociates().Result : JsonConvert.DeserializeObject<IEnumerable<AssociateRM>>(GetREST(GetAssociatesAPI))).ToList();

            Console.WriteLine("Number of retrieved associates = " + (associates?.Count() ?? 0));

            return associates.ToList();
        }

        #endregion Query Methods

        #region Command Methods

        private static AssociateRM CreateAssociate_AtlantaGasLight()
        {
            Console.WriteLine("EFTEST:  Setting up Internal Associate Atlanta Gas Light");

            Commands.V1.Associate.Create createAssociateCommand = new Commands.V1.Associate.Create
            {
                AssociateTypeId = (int)AssociateTypeLookup.AssociateTypeEnum.InternalLDCFacility,
                DUNSNumber = _dunsNumber++,
                IsDeactivating = false,
                IsInternal = true,
                IsParent = false,
                LongName = "Atlanta Gas Light",
                ShortName = "AGL",
                StatusCodeId = (int)StatusCodeLookup.StatusCodeEnum.Active
            };
            
            return _technologyType == 1 ? (AssociateRM)_appService.Handle(createAssociateCommand).Result :
                CreateAssociateWithREST(createAssociateCommand);
        }

        private static PhoneRM AddPrimaryEmailForAssociate(AssociateRM associateRM, PhoneTypeLookup.PhoneTypeEnum phoneType)
        {
            return new PhoneRM();
        }

        private static ContactRM CreateContact_JoeFrancis(AssociateRM associateRM)
        {
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

            return _technologyType == 1 ? (ContactRM)_appService.Handle(createContactForAssociateCommand).Result :
                CreateContactForAssociateWithREST(associateRM.Id, createContactCommand);
        }

        private static UserRM CreateUserForContact(AssociateRM associateRM, ContactRM contactRM)
        {
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

            return _technologyType == 1 ? (UserRM)_appService.Handle(createUserForAssociateCommand).Result :
                CreateUserForAssociateWithREST(createUserForAssociateCommand);
        }

        private static CustomerRM CreateCustomer_WalMart(AssociateRM associateRM)
        {
            Console.WriteLine("EFTEST:  Setting up WalMart customer for Associate");

            Commands.V1.Customer.Create createCustomerCommand = new Commands.V1.Customer.Create
            {
                StartDate = DateTime.Now,
                AccountNumber = "12345678",
                AlternateCustomerId = 1,
                BalancingLevelId = 1,
                BasicPoolId = 1,
                ContractTypeId = 1,
                CurrentDemand = 1,
                DUNSNumber = _dunsNumber++,
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

            return _technologyType == 1 ? (CustomerRM)_appService.Handle(createCustomerForAssociateCommand).Result :
                CreateCustomerForAssociateWithREST(createCustomerForAssociateCommand);
        }

        private static OperatingContextRM GetOperatingContext(CustomerRM customerRM)
        {
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

            Commands.V1.OperatingContext.CreateForCustomer createOperatingContextForCustomerCommand =
                new Commands.V1.OperatingContext.CreateForCustomer(customerRM.Id, createOperatingContextCommand);

            return _technologyType == 1 ? (OperatingContextRM)_appService.Handle(createOperatingContextForCustomerCommand).Result :
                CreateOperatingContextForCustomerWithREST(createOperatingContextForCustomerCommand);
        }

        private static OperatingContextRM GetOperatingContextForAssociate(AssociateRM associateRM)
        {
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

            Commands.V1.OperatingContext.CreateForAssociate createOperatingContextForAssociateCommand =
                new Commands.V1.OperatingContext.CreateForAssociate(associateRM.Id, createOperatingContextCommand);

            return _technologyType == 1 ? (OperatingContextRM)_appService.Handle(createOperatingContextForAssociateCommand).Result : 
                CreateOperatingContextForAssociateWithREST(associateRM.Id, createOperatingContextCommand);
        }

        private static AssociateRM SetUpAGLServicesAgent()
        {

            Console.WriteLine("EFTEST:  Setting up AGL Services Agent");

            Commands.V1.Associate.Create createAssociateCommandForAgent = new Commands.V1.Associate.Create
            {
                AssociateTypeId = ExternalAssociateTypeLookup.ActingAssociateTypes[(int)ExternalAssociateTypeLookup.ExternalAssociateTypeEnum.AssetManager].ActingAssociateTypeId,
                DUNSNumber = _dunsNumber++,
                IsDeactivating = false,
                IsInternal = true,
                IsParent = false,
                LongName = "AGL Services",
                ShortName = "SCS",
                StatusCodeId = (int)StatusCodeLookup.StatusCodeEnum.Active
            };

            return _technologyType == 1 ? (AssociateRM)_appService.Handle(createAssociateCommandForAgent).Result :
                CreateAssociateWithREST(createAssociateCommandForAgent);
        }

        private static UserRM CreateUserForAgent(ContactRM contactRM, AssociateRM associateRM)
        {
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

            return _technologyType == 1 ? (UserRM)_appService.Handle(createUserForAgent).Result : 
                CreateUserForAssociateWithREST(createUserForAgent);
        }

        private static AssociateRM SetUpThirdPartyAssetManager()
        {
            Console.WriteLine("EFTEST:  Set up third party asset manager");

            Commands.V1.Associate.Create createAssetManagerForTPS = new Commands.V1.Associate.Create
            {
                AssociateTypeId = ExternalAssociateTypeLookup.ActingAssociateTypes[(int)ExternalAssociateTypeLookup.ExternalAssociateTypeEnum.AssetManager].ActingAssociateTypeId,
                DUNSNumber = _dunsNumber++,
                IsDeactivating = false,
                IsInternal = true,
                IsParent = false,
                LongName = "AGL Services",
                ShortName = "SCS",
                StatusCodeId = (int)StatusCodeLookup.StatusCodeEnum.Active
            };

            return _technologyType == 1 ? (AssociateRM)_appService.Handle(createAssetManagerForTPS).Result :
                CreateAssociateWithREST(createAssetManagerForTPS);
        }

        private static AssociateRM SetUpAssociateAsPredecessor()
        {
            Console.WriteLine("EFTEST:  Set up associate as predecessor");

            Commands.V1.Associate.Create createPredecessor = new Commands.V1.Associate.Create
            {
                AssociateTypeId = (int)AssociateTypeLookup.AssociateTypeEnum.InternalLDCFacility,
                DUNSNumber = _dunsNumber++,
                IsDeactivating = false,
                IsInternal = true,
                IsParent = false,
                LongName = "AGL Services",
                ShortName = "SCS",
                StatusCodeId = (int)StatusCodeLookup.StatusCodeEnum.Active
            };

            return _technologyType == 1 ? (AssociateRM)_appService.Handle(createPredecessor).Result :
                CreateAssociateWithREST(createPredecessor);
        }

        #endregion Command Methods
    }
}
