using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.Helpers;

namespace Server.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureCors();
            services.ConfigureSqlContext(configuration);
            services.ConfigureRepositoryManager();
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddControllers();
            services.ConfigureApiValidationError(); // must be after AddControllers();
            services.AddSwaggerDocumentation();
            return services;
        }
    }
}