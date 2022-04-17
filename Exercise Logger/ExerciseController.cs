using Exercise_Logger.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_Logger
{
    internal class ExerciseController
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<IEnumerable<Exercise>> GetAllExercises()
        {
            return await _exerciseRepository.Get();
        }

        public async Task<Exercise> GetExercise(int id)
        {
            return await _exerciseRepository.Get(id);
        }

        public async Task PostExercise(Exercise exercise)
        {
            await _exerciseRepository.Create(exercise);
        }

        public async Task PutExercise(Exercise exercise)
        {
            await _exerciseRepository.Update(exercise);
        }

        public async Task DeleteExercise(int id)
        {
            await _exerciseRepository.Delete(id);
        }
    }
}
