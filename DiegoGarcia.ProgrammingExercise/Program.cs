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
            string[] arguments;
            var storageCommand = string.Empty;

            do
            {
                Console.WriteLine("Please insert a valid storage configuration. Valid options:");
                Console.WriteLine("1: memory");
                Console.WriteLine("2: jsonfile /filepath");
                Console.WriteLine("3: database /connectionString");
                Console.WriteLine("Or \"exit\" to quit");
                storageCommand = Console.ReadLine();
                arguments = storageCommand.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Storage = Commands.Instance.ResolveStorage(arguments);

            } while (Storage == null);


            if (Storage != null && !(Storage is EmptyStorage))
            {
                //Load the shapes from storage (if storage type supports it)
                Storage.Load();

                do
                {
                    Console.WriteLine("Please insert a valid command");
                    var command = Console.ReadLine();
                    arguments = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                } while (Commands.Instance.Execute(arguments));

                //Flush the storage (if applies)
                Storage.Flush();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static IStorage GetStorage()
        {
            return new MemoryStorage();
        }
    }
}
