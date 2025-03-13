using Application.Services.Abstractions;

namespace Application.Services.Implementations;

public class WorkerService: IWorkerService
{
    public async Task Run()
    {
        await Task.Run(() =>
        {
            for (var a = 0; a < 100; a++)
            {
                Console.WriteLine(a);
            }
        });

    }
}