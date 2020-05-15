using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GarbageArea.ApplicationServices.GetRouteListUseCase;
using GarbageArea.ApplicationServices.Repositories;
using GarbageArea.DomainObjects.Ports;
using GarbageArea.DomainObjects;
using System.Collections.Generic;

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
            services.AddScoped<InMemoryAreaRepository>(x => new InMemoryAreaRepository(
                new List<Area> {
                    new Area() 
                    { 
                        Id = 1, 
                        Name = "м.Войковская - ст. Ховрино", 
                        Number = "591", 
                        Type = TransportType.Bus, 
                        Organization = x.GetRequiredService<InMemoryAreaTypenRepository>().GetAreaType(2).Result
                    },
                    new Area()
                    {
                        Id = 1,
                        Name = "м.Селигерская - ст. Ховрино",
                        Number = "191",
                        Type = TransportType.Bus,
                        Organization = x.GetRequiredService<InMemoryAreaTypenRepository>().GetAreaType(2).Result
                    },
                    new Area()
                    {
                        Id = 1,
                        Name = "м.Селигерская - ст. Ховрино",
                        Number = "215к",
                        Type = TransportType.Bus,
                        Organization = x.GetRequiredService<InMemoryAreaTypenRepository>().GetAreaType(1).Result
                    }
            }));
            services.AddScoped<IReadOnlyRouteRepository>(x => x.GetRequiredService<InMemoryAreaRepository>());
            services.AddScoped<IRouteRepository>(x => x.GetRequiredService<InMemoryAreaRepository>());

            services.AddScoped<InMemoryAreaTypenRepository>(x => new InMemoryAreaTypenRepository(
                new List<TransportOrganization> { 
                    new TransportOrganization() { Id = 1, Name = "ГУП \"Мосгортранс\"", TimeZone = "Moscow/Europe", WebSite = "http://mosgortrans.ru" },
                    new TransportOrganization() { Id = 2, Name = "ООО \"Трансавтолиз\"", TimeZone = "Moscow/Europe", WebSite = "http://avtoline.ru" } 
                }
            ));
            services.AddScoped<IReadOnlyTransportOrganizationRepository>(x => x.GetRequiredService<InMemoryAreaTypenRepository>());
            services.AddScoped<ITransportOrganizationRepository>(x => x.GetRequiredService<InMemoryAreaTypenRepository>());

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
