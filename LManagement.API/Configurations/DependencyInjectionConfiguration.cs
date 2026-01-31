using LManagement.Application.Interfaces;
using LManagement.Application.Interfaces.Services;
using LManagement.Application.Services;
using LManagement.Infrastructure.Providers;
using LManagement.Infrastructure.Repositories;
using LManagement.Infrastructure.Repositories.Interfaces;

namespace LManagement.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            // Register AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Register Providers
            services.AddSingleton<ISortFieldsProvider, SortFieldsProvider>();

            // Register Repositories
            services.AddScoped<ILeadRepository, LeadRepository>();

            // Register Services
            services.AddScoped<ILeadService, LeadService>();
        }
    }
}