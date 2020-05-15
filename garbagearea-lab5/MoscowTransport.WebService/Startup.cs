using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GarbageArea.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using GarbageArea.ApplicationServices.GetRouteListUseCase;
using GarbageArea.ApplicationServices.Ports.Gateways.Database;
using GarbageArea.ApplicationServices.Repositories;
using GarbageArea.DomainObjects.Ports;

namespace GarbageArea.WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TypeContext>(opts => 
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "MoscowTransport.db")}")
            );

            services.AddScoped<ITypeDatabaseGateway, TypeEFSqliteGateway>();

            services.AddScoped<DbAreaRepository>();
            services.AddScoped<IReadOnlyRouteRepository>(x => x.GetRequiredService<DbAreaRepository>());
            services.AddScoped<IRouteRepository>(x => x.GetRequiredService<DbAreaRepository>());

            services.AddScoped<DbAreaTypeRepository>();
            services.AddScoped<IReadOnlyTransportOrganizationRepository>(x => x.GetRequiredService<DbAreaTypeRepository>());
            services.AddScoped<ITransportOrganizationRepository>(x => x.GetRequiredService<DbAreaTypeRepository>());


            services.AddScoped<IGetRouteListUseCase, GetRouteListUseCase>();

            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
