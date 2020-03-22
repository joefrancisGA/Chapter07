using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;
using EGMS.BusinessAssociates.API.Api;
using EGMS.BusinessAssociates.API.Infrastructure;
using EGMS.BusinessAssociates.Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace EGMS.BusinessAssociates.API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment environment)
        {
            Environment = environment;

            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        private IConfiguration Configuration { get; }
        private IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                o.JsonSerializerOptions
                    .Converters
                    .Add(new JsonStringEnumConverter());
            });

            string connectionString = Configuration["ConnectionStrings:BusinessAssociates"];
                //"Server=localhost\\egms;Database=BusinessAssociates;Trusted_Connection=True"; 

            services.AddScoped<DbConnection>(c => new SqlConnection(connectionString));
            services.AddTransient(_ => new EGMSDb(connectionString));
            services.AddScoped<IAssociateRepository>(x => new AssociateRepository(x.GetRequiredService<EGMSDb>()));
            services.AddScoped<AssociatesApplicationService>();

            // Type converter is to get Swagger to show enum values
            //services.AddMvc();//.AddJsonOptions(options =>
            //    options.JsonSerializerOptions.Converters.Add(new StringEnumConverter()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Business Associates",
                        Version = "v1"
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();
            app.UseRouting();
            
            app.UseEndpoints(endpoints => { endpoints.MapControllerRoute("default", "[controller]/{action=Index}/{id?}"); });

            //app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Business Associates v1"));
        }
    }
}