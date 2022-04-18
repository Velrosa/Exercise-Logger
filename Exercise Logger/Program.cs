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

            //UserInput userInput = new UserInput(new ExerciseService(new ExerciseController(new ExerciseRepository(new ExerciseContext()))));
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
