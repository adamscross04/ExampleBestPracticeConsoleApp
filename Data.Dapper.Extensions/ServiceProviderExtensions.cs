using System.Diagnostics.CodeAnalysis;
using Data.Dapper.Extensions.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Dapper.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceProviderExtensions
{
    /// <summary>
    ///     Registers the application validation services with the specified service collection.
    /// </summary>
    /// <param name="services">The service collection to add the services to.</param>
    public static void RegisterDatabaseExtensions(this IServiceCollection services)
    {
        services.AddTransient<IDbConnectionWrapper, DbConnectionWrapper>();
    }
}