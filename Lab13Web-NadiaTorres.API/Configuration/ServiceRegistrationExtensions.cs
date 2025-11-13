using Lab13Web_NadiaTorres.Infrastructure.Configuration;
using Microsoft.OpenApi.Models;

namespace Lab13Web_NadiaTorres.API.Configuration;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Register application services here
        services.AddHttpContextAccessor();
        
        // Pass configuration to AddInfrastructureServices
        services.AddInfrastructureServices(configuration);
        
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Lab11 NadiaTorres",
                Version = "v1",
                Description = "API para gestionar tickets"
            });
        });
        
        return services;
    }
}