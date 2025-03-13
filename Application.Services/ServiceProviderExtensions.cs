using Application.Services.Abstractions;
using Application.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services;

public static class ServiceProviderExtensions
{
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IWorkerService, WorkerService>();
    }
}