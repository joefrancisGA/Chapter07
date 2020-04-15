using System;
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
            try
            {
                var mapperConfig = new MapperConfiguration(cfg => { cfg.CreateMap<Associate, AssociateRM>(); });

                IMapper mapper = new Mapper(mapperConfig);
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

                AssociateRM associateRM = ((Task<AssociateRM>) appService.Handle(createAssociateCommand).Result).Result;

                // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

                // Set up Contact
                // TO DO:  AddAssociate UserId later

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

                ContactRM contactRM = (ContactRM) appService.Handle(createContactForAssociateCommand).Result;

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
            catch (Exception ex)
            {
                ex = ex;
            }
        }
    }
}
