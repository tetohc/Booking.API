using Microsoft.Extensions.DependencyInjection;

namespace Tarker.Booking.Common
{
    public static class DependencyInjectionService
    {
        /// <summary>
        /// Registers the services used in the project.
        /// </summary>
        /// <param name="services">The services collection where services are added.</param>
        /// <returns>The updated services collection.</returns>
        public static IServiceCollection AddCommon(this IServiceCollection services)
        {
            return services;
        }
    }
}