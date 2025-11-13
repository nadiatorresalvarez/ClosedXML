using Lab13Web_NadiaTorres.Application.MappersProfile;
using Microsoft.Extensions.DependencyInjection;

namespace Lab13Web_NadiaTorres.Application.Configuration;

public static class ApplicationAssemblyMarker
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register application services here
        services.AddAutoMapper(typeof(MappingProfile));
        
        return services;
    }
}