using Exercise_Logger.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_Logger
{
    internal class ExerciseRepository : IExerciseRepository
    {
        private readonly ExerciseContext _context;

        public ExerciseRepository(ExerciseContext context)
        {
            _context = context;
        }

        public async Task Create(Exercise exercise)
        {
            _context.Exercise.Add(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var exerciseToDelete = await _context.Exercise.FindAsync(id);
            _context.Exercise.Remove(exerciseToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Exercise>> Get()
        {
            return await _context.Exercise.ToListAsync();
        }

        public async Task<Exercise> Get(int id)
        {
            return await _context.Exercise.FindAsync(id);
        }

        public async Task Update(Exercise exercise)
        {
            var exerciseToUpdate = await _context.Exercise.FindAsync(exercise.Id);

            _context.Entry(exerciseToUpdate).CurrentValues.SetValues(exercise);
            await _context.SaveChangesAsync();
        }
    }
}
