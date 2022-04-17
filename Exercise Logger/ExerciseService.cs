using Exercise_Logger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_Logger
{
    internal class ExerciseService
    {
        
        private readonly ExerciseController _controller;

        public ExerciseService(ExerciseController controller)
        {
            _controller = controller;
        }

        public async Task<List<Exercise>> ShowingAllExercises()
        {
            return (List<Exercise>)await _controller.GetAllExercises();
        }

        public async Task<Exercise> FetchExercise(int id)
        {
            Exercise exercise = await _controller.GetExercise(id);
            return exercise;
        }
        public async Task CreateExercise(Exercise exercise)
        {
            await _controller.PostExercise(exercise);
        }

        public async Task UpdateExercise(Exercise exercise)
        {
            await _controller.PutExercise(exercise);
        }

        public async Task DeleteExercise(int id)
        {
            await _controller.DeleteExercise(id);
        }
    }
}
