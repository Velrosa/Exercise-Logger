using Exercise_Logger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_Logger
{
    internal class UserInput
    {
        private readonly ExerciseService _exerciseService;

        public UserInput(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        public async Task MainMenu()
        {
            Console.Clear();

            Console.WriteLine("\n MAIN MENU\n\n" +
                                " What would you like to do?\n\n" +
                                " Type 0 to Close Application.\n" +
                                " Type 1 to Get all Exercise records.\n" +
                                " Type 2 to Get a specific Exercise Record.\n" +
                                " Type 3 to Create a Exercise record.\n" +
                                " Type 4 to Update a Exercise record.\n" +
                                " Type 5 to Delete a Exercise record.\n");

            string selector = Convert.ToString(Console.ReadKey(true).KeyChar);

            Console.Clear();
            Console.WriteLine(" Type MENU to return.");

            switch (selector)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    await FetchAllExercises();
                    break;
                case "2":
                    await FetchSingleExercise();
                    break;
                case "3":
                    await InputAddExercise();
                    break;
                case "4":
                    await InputEditExercise();
                    break;
                case "5":
                    await InputDeleteExercise();
                    break;
                default:
                    Console.Write(" Invalid Entry.");
                    break;
            }

            Console.WriteLine("\n Press any key to return... ");
            Console.ReadKey();
        }

        internal async Task FetchAllExercises()
        {
            Console.WriteLine("\n Displaying all Exercises... \n");
            List<Exercise> tableData = await _exerciseService.ShowingAllExercises();
            TableVisuals.ShowTable(tableData);
        }
        internal async Task FetchSingleExercise()
        {
            Console.WriteLine("\n Fetching a single Exercise... ");
            Console.Write("\n Enter the ID you wish to fetch: ");
            string id = Validator.IsNumberValid(Console.ReadLine());
            if (id == "MENU") return;
            
            List<Exercise> tableData = new List<Exercise>();
            Exercise exercise = await _exerciseService.FetchExercise(int.Parse(id));
            tableData.Add(exercise);
            TableVisuals.ShowTable(tableData);
        }

        
        internal async Task InputAddExercise()
        {
            Exercise exercise = new();

            Console.WriteLine("\n Adding a new Exercise...");
            
            Console.Write("\n Start Date (DD/MM/YY HH:MM): ");
            string start = Validator.IsDateValid(Console.ReadLine());
            if (start == "MENU") return;
            exercise.DateStart = DateTime.Parse(start);
            
            Console.Write("\n End Date (DD/MM/YY HH:MM): ");
            string end = Validator.IsDateValid(Console.ReadLine());
            if (end == "MENU") return;
            exercise.DateEnd = DateTime.Parse(end);

            CheckTimeSpan(exercise);
            if(exercise.Duration.TotalMinutes == 0) return;
            
            Console.Write("\n Comments: ");
            string comment = Validator.IsStringValid(Console.ReadLine());
            if (comment == "MENU") return;
            exercise.Comments = comment;

            await _exerciseService.CreateExercise(exercise);
        }

        internal async Task InputEditExercise()
        {
            Exercise exercise = new Exercise();
            
            await FetchAllExercises();
            
            Console.WriteLine("\n Updating an Exercise...");

            Console.Write("\n Enter the ID of the record you wish to change: ");
            string id = Console.ReadLine();
            if (id == "MENU") return;
            exercise.Id = int.Parse(id);

            Console.Write("\n Start Date (DD/MM/YY HH:MM): ");
            string start = Validator.IsDateValid(Console.ReadLine());
            if (start == "MENU") return;
            exercise.DateStart = DateTime.Parse(start);

            Console.Write("\n End Date (DD/MM/YY HH:MM): ");
            string end = Validator.IsDateValid(Console.ReadLine());
            if (end == "MENU") return;
            exercise.DateEnd = DateTime.Parse(end);

            CheckTimeSpan(exercise);
            if(exercise.Duration.TotalMinutes == 0) return;

            Console.Write("\n Comments: ");
            string comment = Validator.IsStringValid(Console.ReadLine());
            if (comment == "MENU") return;
            exercise.Comments = comment;

            await _exerciseService.UpdateExercise(exercise);
        }

        internal async Task InputDeleteExercise()
        {
            Console.WriteLine("\n Deleting an Exercise...");

            await FetchAllExercises();

            Console.Write("\n Enter the ID of the record you wish to delete: ");
            string id = Console.ReadLine();
            if (id == "MENU") return;

            Console.Write($"\n Are you sure you wish to delete the Shift above? (y or n) ");
            string entry = Console.ReadLine();
            if (entry != "y") return;

            await _exerciseService.DeleteExercise(int.Parse(id));
        }

        internal void CheckTimeSpan(Exercise exercise)
        {
            if(exercise.DateEnd <= exercise.DateStart)
            {
                Console.WriteLine("\n Invalid Timespan between dates provided.");
                return;
            }
            
            int hoursPassed = exercise.DateEnd.Hour - exercise.DateStart.Hour;
            
            if(hoursPassed > 24)
            {
                Console.WriteLine("\n No more than 24 hours between dates");
                return;
            }
            
            exercise.Duration = exercise.DateEnd - exercise.DateStart;
        }
    }
}
