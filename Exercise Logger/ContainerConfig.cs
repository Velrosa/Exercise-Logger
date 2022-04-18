using Autofac;
using Exercise_Logger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_Logger
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<StartUp>();
            builder.RegisterType<UserInput>();
            builder.RegisterType<ExerciseService>();
            builder.RegisterType<ExerciseController>();
            builder.RegisterType<ExerciseRepository>().As<IExerciseRepository>();
            builder.RegisterType<ExerciseContext>();
            
            return builder.Build();
        }
    }
}
