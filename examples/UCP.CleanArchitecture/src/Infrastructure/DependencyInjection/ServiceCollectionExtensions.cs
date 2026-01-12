namespace Infrastructure.DependencyInjection;

using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UCP.NET.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Register repositories
        services.AddSingleton<IShoppingCartRepository, InMemoryShoppingCartRepository>();
        services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();

        // Register UCP client
        services.AddUcpShoppingClient(configuration);

        return services;
    }
}
