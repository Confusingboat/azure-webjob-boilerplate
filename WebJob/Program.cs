using Microsoft.Azure.WebJobs;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebJob
{
    public class Program
    {
        static JobHost host = null;
        public static async Task Main(string[] args)
        {
            Trace.TraceInformation("Webjob started");
            var cancellationToken = new WebJobsShutdownWatcher().Token;
            cancellationToken.Register(() =>
            {
                Trace.TraceInformation("Cancellation received");
                host.Stop();
            });
            var jobHostConfig = new JobHostConfiguration
            {
                HostId = Guid.NewGuid().ToString("N"),
                StorageConnectionString = string.Empty,
                DashboardConnectionString = string.Empty
            };
            host = new JobHost(jobHostConfig);
            await host.CallAsync(nameof(OneTimeTask));
            Trace.TraceInformation("Webjob terminated");
        }

        [NoAutomaticTrigger]
        public static async Task OneTimeTask()
        {
            // Simulate some work
            await Task.Delay(2000);
            Trace.TraceInformation($"{nameof(OneTimeTask)} executed");
        }
    }
}
