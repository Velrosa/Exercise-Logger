using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Exercise_Logger.Models
{

    internal class ExerciseContext : DbContext
    {
        public DbSet<Exercise> Exercise { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Database=ExerciseDB;Integrated Security=True");
        }
    }
}
