using Microsoft.Azure.WebJobs;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

// If you change the assembly name (which I recommend),
// don't forget to update the run.bat file
namespace WebJob
{
    public class Program
    {
        static JobHost host = null;
        public static async Task Main(string[] args)
        {
            Console.WriteLine($"{nameof(WebJob)} started");
            var cancellationToken = new WebJobsShutdownWatcher().Token;
            cancellationToken.Register(() =>
            {
                Console.WriteLine("Cancellation received");
                host.Stop();
            });
            // Assuming you want to get your shitty code up in the cloud ASAP
            // so I've created this minimalistic config
            var jobHostConfig = new JobHostConfiguration
            {
                HostId = Guid.NewGuid().ToString("N"),
                StorageConnectionString = string.Empty,
                DashboardConnectionString = string.Empty
            };
            host = new JobHost(jobHostConfig);
            await host.CallAsync(nameof(OneTimeTask));
            Console.WriteLine($"{nameof(WebJob)} terminated");
        }

        [NoAutomaticTrigger]
        public static async Task OneTimeTask()
        {
            // Put your bullshit in here

            // Simulate some work by making you wait
            await Task.Delay(2000);

            Console.WriteLine($"{nameof(OneTimeTask)} executed");
        }
    }
}
