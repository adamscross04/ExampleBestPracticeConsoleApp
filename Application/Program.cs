using Application.Services;
using Application.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.RegisterApplicationServices();
    })
    .Build();

IWorkerService service = host.Services.GetRequiredService<IWorkerService>();
Task result = service.Run();

Console.WriteLine(result);

await host.RunAsync();