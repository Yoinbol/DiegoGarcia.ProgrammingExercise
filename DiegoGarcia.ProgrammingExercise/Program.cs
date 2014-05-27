using DiegoGarcia.ProgrammingExercise.Storage;
using System;

namespace DiegoGarcia.ProgrammingExercise
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        public static IStorage Storage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Storage = ConfigureStorage();

            string[] arguments;

            do
            {
                Console.WriteLine("Please insert a valid command");
                var command = Console.ReadLine();
                arguments = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            } while (Commands.Instance.Execute(arguments));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static IStorage ConfigureStorage()
        {
            return new MemoryStorage();
        }
    }
}
