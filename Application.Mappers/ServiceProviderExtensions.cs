using System.Diagnostics.CodeAnalysis;
using Application.Mappers.Abstractions;
using Application.Mappers.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Mappers;


[ExcludeFromCodeCoverage]
public static class ServiceProviderExtensions
{
    /// <summary>
    ///     Registers the application validation services with the specified service collection.
    /// </summary>
    /// <param name="services">The service collection to add the services to.</param>
    public static void RegisterApplicationMappers(this IServiceCollection services)
    {
        services.AddTransient<IUserDtoMapper, UserDtoMapper>();
        services.AddTransient<IProductDtoMapper, ProductDtoMapper>();
    }
}