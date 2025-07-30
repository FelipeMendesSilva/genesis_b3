using Cdb.App.Handlers;
using Cdb.App.Interfaces;
using Cdb.Domain.Interfaces;
using Cdb.Domain.Services;

namespace Cdb.API.IoC;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICdbCalculatorService, CdbCalculatorService>();
        services.AddScoped<ICdbHandler, CdbHandler>();

        return services;
    }
}