using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Api.Web.WebApi.Models.DBVenta;
using Api.Web.WebApi.Infrastructure.Interfaces;
using Api.Web.WebApi.Infrastructure.Services;
using Api.Web.WebApi.Infrastructure.Repository;
using Api.Web.WebApi.Models.DBIdenity;

namespace Api.Web.WebApi.Infrastructure.ServiceConection
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<DBContextVenta>(options =>
            //{
            //    options.UseSqlServer(configuration.GetConnectionString("CadenaSQL"));
            //});
            services.AddDbContext<DBContextVenta>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CadenaSQL")),
            ServiceLifetime.Scoped);
            services.AddDbContext<IdentityContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"));
            });

            services.AddScoped<IServicesGeneric, ServicesGeneric>();
            services.AddScoped<IRepositoryGeneric, RepositoryGeneric>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<ISinisterRepository, SinisterRepository>();
            return services;
        }
    }
}
