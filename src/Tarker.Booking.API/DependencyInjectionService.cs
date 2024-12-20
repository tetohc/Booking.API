using System.Reflection;

namespace Tarker.Booking.API
{
    /// <summary>
    /// Provides methods to register services in the project.
    /// </summary>
    public static class DependencyInjectionService
    {
        /// <summary>
        /// Registers the services used in the project.
        /// </summary>
        /// <param name="services">The services collection where services are added.</param>
        /// <returns>The updated services collection.</returns>
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Tarker Booking API",
                    Description = "API Management for Booking App",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Jerry HC",
                        Email = "",
                        Url = new Uri("https://www.google.com"),
                    }
                });

                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, fileName));
            });
            return services;
        }
    }
}