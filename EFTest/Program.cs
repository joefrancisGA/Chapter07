using System;
using System.ComponentModel.Design;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using EGMS.BusinessAssociates.Command;
using EGMS.BusinessAssociates.Data.EF;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Domain.Enums;
using Microsoft.Extensions.Configuration;
using EGMS.BusinessAssociates.Query.ReadModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

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

            // Set up relationship between Associate and User

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set up Customer for Associate - can we get rid of this and just use relationship object

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set up relationship between Associate and Customer

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set Up Operating Context

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set up relationship between User and OperatingContext

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set up relationship between Associate and OperatingContext

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set up Associate as Agent

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // AddAssociate Users to Agent

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set up OperatingContext for Associate for Third-Party Suppliers

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set up Associate as predecessor

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set up relationship between Associate and Predecessors


            //Commands.V1.

            //appService.Handle()
        }
    }
}
