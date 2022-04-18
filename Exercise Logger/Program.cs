using Autofac;
using Exercise_Logger.Models;
using System;
using System.Threading.Tasks;

namespace Exercise_Logger
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            while (true)
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    var startup = scope.Resolve<StartUp>();
                    { }
                    await startup.Run();
                }
            }
        }
    }
}
