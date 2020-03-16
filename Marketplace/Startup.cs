using System.Threading.Tasks;
using BusinessAssociates.Api;
using BusinessAssociates.Domain;
using BusinessAssociates.Framework;
using BusinessAssociates.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents;
using Swashbuckle.AspNetCore.Swagger;

// ReSharper disable UnusedMember.Global

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
            var store = new DocumentStore
              {
                  Urls = new[] {"http://localhost:8080"},
                  Database = "Marketplace_Chapter6",
                  Conventions =
                  {
                      FindIdentityProperty = m => m.Name == "_databaseId"
                  }
              };
            store.Conventions.RegisterAsyncIdConvention<Domain.InternalAssociate>(
                (dbName, entity) => Task.FromResult("InternalAssociate/" + entity.Id.ToString()));
            store.Initialize();

            services.AddScoped(c => store.OpenAsyncSession());
            services.AddScoped<IUnitOfWork, RavenDbUnitOfWork>();
            services.AddScoped<IInternalAssociateRepository, InternalAssociateRepository>();
            services.AddScoped<InternalAssociatesApplicationService>();

            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "InternalAssociates",
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