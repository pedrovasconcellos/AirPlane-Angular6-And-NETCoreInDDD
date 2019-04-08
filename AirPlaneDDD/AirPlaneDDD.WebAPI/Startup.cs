using Microsoft.AspNetCore.Mvc.Versioning;
using Swashbuckle.SwaggerConfigurationExtension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AirPlaneDDD.Domain.Interfaces.Generic;
using AirPlaneDDD.Infra.Repository.Generic;
using AirPlaneDDD.Domain.Interfaces.AirPlanes;
using AirPlaneDDD.Infra.Repository.AirPlanes;
using AirPlaneDDD.Application.Interfaces;
using AirPlaneDDD.Application.Apps;

namespace AirPlaneDDD.WebAPI
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

            services.AddMvc(options => { });

            services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGeneric<>));
            services.AddSingleton<IAirPlane, RepositoryAirPlane>();
            services.AddSingleton<IAirPlaneModel, RepositoryAirPlaneModel>();
            services.AddSingleton<IAppAirPlane, AppAirPlane>();
            services.AddSingleton<IAppAirPlaneModel, AppAirPlaneModel>();


            services.AddApiVersioning(options =>
            {
                options.ApiVersionReader = new QueryStringApiVersionReader();
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
                options.ReportApiVersions = true;
            });

            var swaggerConfigurationExtension = new SwaggerStartupConfigureServices(services, tokenType: null, apiKeyScheme: null)
                .SetProjectNameAndDescriptionn(projectName: "Air Plane WebAPI", projectDescription: "This project has the purpose of performing an exemplification");

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
            var swaggerStartupConfigure =
                new SwaggerStartupConfigure(app).RedirectToSwagger();
        }
    }
}
