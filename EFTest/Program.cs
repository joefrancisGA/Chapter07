using System;
using AutoMapper;
using AutoMapper.Configuration;
using EGMS.BusinessAssociates.Command;
using EGMS.BusinessAssociates.Data.EF;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
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
            Console.WriteLine("Hello World!");
        }
    }
}
