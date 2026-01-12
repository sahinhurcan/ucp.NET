namespace Infrastructure.DependencyInjection;

using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        // TODO: Register your database context here
        // Example for Entity Framework Core:
        // var connectionString = configuration.GetConnectionString("DefaultConnection");
        // services.AddDbContext<YourDbContext>(options =>
        //     options.UseSqlServer(connectionString));

        // TODO: Register your repository implementations here
        // services.AddScoped<IShoppingCartRepository, YourShoppingCartRepository>();
        // services.AddScoped<IOrderRepository, YourOrderRepository>();

        // TODO: Register your external services here (APIs, HTTP clients, etc.)
        // services.AddHttpClient<IYourApiClient, YourApiClient>(client =>
        // {
        //     client.BaseAddress = new Uri("https://your-api.com");
        // });

        return services;
    }
}
