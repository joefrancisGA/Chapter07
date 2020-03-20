using System.Data.Common;
using System.Data.SqlClient;
using BusinessAssociates.Api;
using BusinessAssociates.Domain.Repositories;
using BusinessAssociates.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
//using Raven.Client.Documents;
using Swashbuckle.AspNetCore.Swagger;


namespace BusinessAssociates
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }
        private IHostingEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //var store = new DocumentStore
            //  {
            //      Urls = new[] {"http://localhost:8080"},
            //      Database = "EGMS",
            //      Conventions =
            //      {
            //          FindIdentityProperty = m => m.Name == "_databaseId"
            //      }
            //  };

            //store.Conventions.RegisterAsyncIdConvention<Associate>(
            //    (dbName, entity) => Task.FromResult("Associate/" + entity.Id));
            //store.Initialize();


            const string connectionString =
                "Server=localhost\\egms;Database=BusinessAssociates;Trusted_Connection=True"; 

            //services.AddScoped(c => store.OpenAsyncSession());
            //services.AddScoped<IUnitOfWork, RavenDbUnitOfWork>();
            services.AddScoped<DbConnection>(c => new SqlConnection(connectionString));
            services.AddTransient(_ => new EGMSDb(connectionString));
            services.AddScoped<IAssociateRepository>(x => new AssociateRepository(x.GetRequiredService<EGMSDb>()));
            services.AddScoped<AssociatesApplicationService>();

            // Tye converter is to get Swagger to show enum values
            services.AddMvc().AddJsonOptions(options =>
                options.SerializerSettings.Converters.Add(new StringEnumConverter()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Business Associates",
                        Version = "v1"
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "InternalAssociates v1"));
        }
    }
}