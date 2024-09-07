using Hangfire.Server;
using Microsoft.Extensions.Hosting;

namespace Psicowise.Domain.Services;

public interface IMonitorService : IHostedService
{
    Task StartAsync(CancellationToken cancellationToken);
    Task StopAsync(CancellationToken cancellationToken);
    Task AddJobHangfireAsync();
    void Print(string message, PerformContext? context);
}