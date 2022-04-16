using Exercise_Logger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_Logger
{
    internal interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> Get();
        Task<Exercise> Get(int id);
        Task<Exercise> Create(Exercise exercise);
        Task Update(Exercise exercise);
        Task Delete(int id);
    }
}
