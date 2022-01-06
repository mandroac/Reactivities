using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Persistence.Wrappers;

namespace API.Extentions
{
    public static class StartupExtentions
    {
        public static IServiceCollection SetupCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IActivitiesRepository, ActivitiesRepository>();
            services.AddScoped<IActivitiesService, ActivitiesService>();
                
            return services;
        }
    }
}