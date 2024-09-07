using System.Runtime.CompilerServices;
using Hangfire;
using Hangfire.Console;
using Hangfire.Server;
using Microsoft.Extensions.Hosting;
using Psicowise.Domain.Services;

namespace Psicowise.Infrastructure.Services;

public class MonitorService : IMonitorService
{
    async Task IHostedService.StartAsync(CancellationToken cancellationToken)
    {
        await AddJobHangfireAsync();
    }

    Task IMonitorService.StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task AddJobHangfireAsync()
    {
        //Agendado
        BackgroundJob.Schedule(() => Print("Agendamento", null), TimeSpan.FromSeconds(5));

        //Em Fila
        var jobId = BackgroundJob.Enqueue("test",() => Print("Em Fila", null));

        //Roda um processo a partir de um Id Pai
        BackgroundJob.ContinueJobWith(jobId, () => Print("Continuação", null));

        //Recorrente
        RecurringJob.AddOrUpdate("Recurrent", () => Print("Recorrente", null), Cron.Minutely);
    }

    public void Print(string message, PerformContext? context)
    {
        context.WriteLine(message);
    }

    Task IMonitorService.StartAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task IHostedService.StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}