using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tarker.Booking.External
{
    public static class DependencyInjectionService
    {
        /// <summary>
        /// Registers the services used in the project.
        /// </summary>
        /// <param name="services">The services collection where services are added</param>
        /// <param name="configuration">The application configuration used to configure services.</param>
        /// <returns>The updated services collection.</returns>
        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}