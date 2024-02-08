using AutoMapper;
using Data.LaTavernaMenu;
using Data.LaTavernaMenu.Interfaces.Repositories;
using Data.LaTavernaMenu.Mappings;
using Data.LaTavernaMenu.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Extensions.DependencyInjection
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlServices(this IServiceCollection services, IConfiguration configuration)
        {
            string sqlConnectionString = configuration.GetConnectionString("LaTavernaMenu") ?? string.Empty;

            services.AddDbContext<AppDBContext>(options =>
                   options.UseSqlServer(sqlConnectionString));

            services.AddScoped<ISectionRepository, SectionRepositoryImpl>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new SqlMappingProfile()); // Aggiungi i profili di AutoMapper necessari
                                                        // Puoi aggiungere più profili se necessario
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }  
}
