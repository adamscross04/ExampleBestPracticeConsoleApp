using Data.Repositories.Abstractions;
using Data.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Repositories;

public static class ServiceProviderExtensions
{
    /// <summary>
    ///     Registers the application validation services with the specified service collection.
    /// </summary>
    /// <param name="services">The service collection to add the services to.</param>
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
    }
}