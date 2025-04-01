using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Factories;

[ExcludeFromCodeCoverage]
public static class ServiceProviderExtensions
{
    /// <summary>
    ///     Registers the application validation services with the specified service collection.
    /// </summary>
    /// <param name="services">The service collection to add the services to.</param>
    public static void RegisterDomainFactories(this IServiceCollection services)
    {
        services.AddTransient<IProductFactory, ProductFactory>();
    }
}