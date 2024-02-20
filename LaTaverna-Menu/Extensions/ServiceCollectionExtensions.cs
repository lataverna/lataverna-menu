using AutoMapper;
using Core.LaTavernaMenu.Interfaces.Repositories;
using Core.LaTavernaMenu.Interfaces.Services;
using Data.LaTavernaMenu;
using Data.LaTavernaMenu.Mappings;
using Data.LaTavernaMenu.Repositories;
using LaTaverna_Menu.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Extensions.DependencyInjection
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISectionService, SectionServiceImpl>();
            services.AddScoped<IDishService, DishServiceImpl>();

            return services;
        }
    }  
}
