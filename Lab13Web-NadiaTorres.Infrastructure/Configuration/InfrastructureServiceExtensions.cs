using Lab13Web_NadiaTorres.Application.Interfaces;
using Lab13Web_NadiaTorres.Infrastructure.Adapters.Repositories;
using Lab13Web_NadiaTorres.Infrastructure.Adapters.Services;
using Lab13Web_NadiaTorres.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab13Web_NadiaTorres.Infrastructure.Configuration;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Register infrastructure services here
        
        // Configuración de la conexión a la base de datos
        services.AddDbContext<dbContextLab13>((serviceProvider, options) =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IExcelService, ExcelService>();
        
        return services;
    }
}