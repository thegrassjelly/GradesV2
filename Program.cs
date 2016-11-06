using System;
using System.IO;

namespace GradesV2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleInit();
            GradeTracker book = CreateGradeBook();

            //GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);

            Console.ReadLine();
        }

        private static GradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void ConsoleInit()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("_______________________________________________________________");
            Console.WriteLine("                              C# 2015                          ");
            Console.WriteLine("_______________________________________________________________");
            Console.WriteLine("");
        }

        private static void WriteResults(GradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(GradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrade(outputFile);
            }
        }

        private static void AddGrades(GradeTracker book)
        {
            book.AddGrade(89.5f);
            book.AddGrade(75);
            book.AddGrade(91);
        }

        private static void GetBookName(GradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter a name:");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong.. :(" + ex.Message);
            }
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine("{0}: {1}", description, result);
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine("{0} - {1}", description, result);
        }
    }
}
