using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.Extensions;

namespace TestConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            var rnd = new Random();
            var deconat = new Deconat();

            deconat.SubscribeToAdd(s => Console.WriteLine($"Add {s.Name}"));

            for (int i = 0; i < 100; i++)
            {
                var student = new Student {
                    Name = $"Student{i + 1}",
                    Raitings = rnd.GetRandomIntValues(rnd.Next(20, 50), 2, 6).ToList(),
                };
                deconat.Add(student);
            }

            deconat.SaveToFile("students.csv");
            deconat.LoadFromFile("students.csv");

            foreach (var student in deconat)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine(deconat.Average(s => s.AverageRaiting));
            Console.WriteLine(rnd.NextValue(1, 2, 4, 5, 6, 7, 9, 10));

            ProcessStudent(deconat, GetIndexedStudentName);
            ProcessStudent(deconat, GetAverageStudentRaiting);

            Console.ReadKey();
        }

        private static void ProcessStudent(IEnumerable<Student> Students, StudentProcessor Processor)
        {
            var index = 0;
            foreach (var student in Students)
            {
                Console.WriteLine(Processor(student, index++));
            }
        }

        private static string GetIndexedStudentName(Student Std, int Index) => $"{Std.Name}[{Index}]";
        private static string GetAverageStudentRaiting(Student Std, int Index) => $"{Std.Name}: {Std.AverageRaiting:#.00}";

        internal delegate string StudentProcessor(Student Std, int Index);
    }
}
