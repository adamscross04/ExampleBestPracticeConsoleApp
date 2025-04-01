using System.Diagnostics.CodeAnalysis;
using Data.Mappers.Abstractions;
using Data.Mappers.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Mappers;


[ExcludeFromCodeCoverage]
public static class ServiceProviderExtensions
{
    /// <summary>
    ///     Registers the application validation services with the specified service collection.
    /// </summary>
    /// <param name="services">The service collection to add the services to.</param>
    public static void RegisterDataLayerMappers(this IServiceCollection services)
    {
        services.AddTransient<IUserEntityMapper, UserEntityMapper>();
        services.AddTransient<IProductEntityMapper, ProductEntityMapper>();
    }
}