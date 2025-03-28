using System.Diagnostics.CodeAnalysis;
using Domain.Validation.Abstractions;
using Domain.Validation.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Validation;

[ExcludeFromCodeCoverage]
public static class ServiceProviderExtensions
{
    /// <summary>
    ///     Registers the application validation services with the specified service collection.
    /// </summary>
    /// <param name="services">The service collection to add the services to.</param>
    public static void RegisterApplicationValidationServices(this IServiceCollection services)
    {
        services.AddTransient<IProductValidationService, ProductValidationService>();
    }
}