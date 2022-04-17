using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_Logger
{
    internal class TableVisuals
    {
        public static void ShowTable<T>(List<T> tableData) where T : class
        {
            try
            {
                ConsoleTableBuilder.From(tableData).ExportAndWriteLine();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("No records to show.");
            }
        }
    }
}
