using System.Threading.Tasks;
using ExampleConsoleApplication.Factories;
using ExampleConsoleApplication.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleConsoleApplication
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IBootstrapService, BootstrapService>();
            serviceCollection.AddSingleton<IPersonFactory, PersonFactory>();
            serviceCollection.AddSingleton<IPersonListFactory, PersonListFactory>();

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            IBootstrapService bootstrapService = serviceProvider.GetService<IBootstrapService>();
            await bootstrapService.Run(); // can't hear you
        }
    }
}