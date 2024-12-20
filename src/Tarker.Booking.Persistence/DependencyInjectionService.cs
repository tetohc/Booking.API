using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tarker.Booking.Application.DataBase;
using Tarker.Booking.Persistence.DataBase;

namespace Tarker.Booking.Persistence
{
    public static class DependencyInjectionService
    {
        /// <summary>
        /// Registers the persistence services used in the project.
        /// </summary>
        /// <param name="services">The services collection where services are added.</param>
        /// <param name="configuration">The application configuration used to configure services.</param>
        /// <returns>The updated services collection.</returns>
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseService>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SQLConnectionString"));
            });

            services.AddScoped<IDataBaseService, DataBaseService>();
            return services;
        }
    }
}