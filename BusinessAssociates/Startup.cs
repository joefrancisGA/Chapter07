using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using EGMS.BusinessAssociates.API.Infrastructure;
using EGMS.BusinessAssociates.Command;
using EGMS.BusinessAssociates.Data;
using EGMS.BusinessAssociates.Data.EF;
using EGMS.BusinessAssociates.Domain.Repositories;
using EGMS.Facilities.Data.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using EGMSDb = EGMS.BusinessAssociates.Data.EGMSDb;


namespace EGMS.BusinessAssociates.API
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IWebHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true);

            Configuration = builder.Build();
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin();
                    });
            });

            // Just statically reference the EF automapper config for now.
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperEF(Configuration));
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);


            services.AddControllers().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                o.JsonSerializerOptions
                    .Converters
                    .Add(new JsonStringEnumConverter());
            });

            string connectionString = Configuration["ConnectionStrings:BusinessAssociates"];

            services.AddDbContext<AssociatesContext>(opt =>
                opt.UseSqlServer(connectionString)
                    .EnableSensitiveDataLogging());

            services.AddScoped<DbConnection>(c => new SqlConnection(connectionString));
            services.AddTransient(_ => new EGMSDb(connectionString));
            services.AddScoped<IAssociateRepository, AssociateRepositoryEF>();
            //services.AddScoped<IAssociateRepository>(x => new AssociateRepository(x.GetRequiredService<EGMSDb>()));
            services.AddScoped<AssociatesApplicationService>();

            // Type converter is to get Swagger to show enum values
            //services.AddMvc();//.AddJsonOptions(options =>
            //    options.JsonSerializerOptions.Converters.Add(new StringEnumConverter()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Business Commands",
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Business Commands v1"));
        }
    }
}