using System.Diagnostics.CodeAnalysis;
using Domain.Services.Abstractions;
using Domain.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Services;

[ExcludeFromCodeCoverage]
public static class ServiceProviderExtensions
{
    /// <summary>
    ///     Registers the application validation services with the specified service collection.
    /// </summary>
    /// <param name="services">The service collection to add the services to.</param>
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IWorkerService, WorkerService>();
        services.AddTransient<IProductService, ProductService>();
    }
}