using System;
using AutoMapper;
using AutoMapper.Configuration;
using EGMS.BusinessAssociates.Command;
using EGMS.BusinessAssociates.Data.EF;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Domain.Enums;
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
            MapperConfigurationExpression expression = new MapperConfigurationExpression();
            IConfigurationProvider config = new MapperConfiguration(expression);
            IMapper mapper = new Mapper(config);
            ILoggerFactory loggerFactory = new NullLoggerFactory();
            ILogger<AssociateRepositoryEF> logger = new Logger<AssociateRepositoryEF>(loggerFactory);
            BusinessAssociatesContext context = new BusinessAssociatesContext();
            AssociateRepositoryEF repository = new AssociateRepositoryEF(context, logger, mapper);
            AssociatesApplicationService appService = new AssociatesApplicationService(repository, mapper);

            // Set up Associate

            Commands.V1.Associate.Create createAssociateCommand = new Commands.V1.Associate.Create
            {
                AssociateTypeId = (int) AssociateTypeLookup.AssociateTypeEnum.InternalLDCFacility,
                DUNSNumber = 123456789,
                IsDeactivating = false,
                IsInternal = true,
                IsParent = false,
                LongName = "Atlanta Gas Light",
                ShortName = "AGL",
                StatusCodeId = (int) StatusCodeLookup.StatusCodeEnum.Active
            };

            AssociateRM associateRM = (AssociateRM)appService.Handle(createAssociateCommand).Result;

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set up Contact
            // TO DO:  Add UserId later
            
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

            ContactRM contactRM = (ContactRM)appService.Handle(createContactCommand).Result;

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            // Set up User for Contact

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

            // Add Users to Agent

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
