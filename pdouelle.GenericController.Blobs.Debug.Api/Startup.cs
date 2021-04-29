using Autofac;
using douell_p.GenericMediatR;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using pdouelle.GenericController.Blob;
using pdouelle.GenericController.Blob.Factory;
using pdouelle.GenericController.Blobs.Debug.Api.Data;

namespace pdouelle.GenericController.Blobs.Debug.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();

            services.AddMediatR(typeof(Startup).Assembly);
            services.AddGenericMediatR(typeof(Startup).Assembly);
            services.AddGenericControllers();
            services.AddAutoMapper(typeof(Startup).Assembly);

            var connectionStringAzureStorage = Configuration.GetConnectionString("Storage");
            services.AddAzureClients(builder => { builder.AddBlobServiceClient(connectionStringAzureStorage); });

            var connectionString = Configuration.GetConnectionString("Database");
            services.AddDbContext<DatabaseService>(options => { options.UseSqlServer(connectionString); });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo {Title = "pdouelle.GenericController.Blobs.Debug.Api", Version = "v1"});
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "pdouelle.GenericController.Blobs.Debug.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.ConfigureContainer(typeof(DatabaseService));
        }
    }
}