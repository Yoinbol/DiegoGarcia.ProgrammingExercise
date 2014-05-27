using DiegoGarcia.ProgrammingExercise.Shapes;
using DiegoGarcia.ProgrammingExercise.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace DiegoGarcia.ProgrammingExercise
{
    public class Commands
    {
        /// <summary>
        /// 
        /// </summary>
        public static Commands Instance = new Commands();

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, Action<string[]>> Cmds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, Func<string[], IStorage>> StorageCmds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private Commands()
        {
            ConfigureStorageCommands();
            ConfigureCommands();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ConfigureStorageCommands()
        {
            this.StorageCmds = new Dictionary<string, Func<string[], IStorage>>();

            this.StorageCmds.Add("memory", (args) => 
            {
                return new MemoryStorage();
            });

            this.StorageCmds.Add("jsonfile", (args) =>
            {
                if (args.Any())
                {
                    var filePath = args[0];

                    if (File.Exists(filePath))
                    {
                        return new JsonFileStorage(filePath);
                    }
                    else
                    {
                        Console.WriteLine("Invalid file path");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid arguments");
                }

                return null;
            });

            this.StorageCmds.Add("database", (args) =>
            {
                Console.WriteLine("Database storage under construction");
                return null;
            });

            this.StorageCmds.Add("cls", (args) =>
            {
                Console.Clear();
                return null;
            });

            this.StorageCmds.Add("exit", (args) =>
            {
                return new EmptyStorage();
            });
        }

        /// <summary>
        /// 
        /// </summary>
        private void ConfigureCommands()
        {
            this.Cmds = new Dictionary<string, Action<string[]>>();

            this.Cmds.Add("help", (args) =>
            {
                Console.WriteLine("Help under construction...");
            });

            this.Cmds.Add("square", (args) =>
            {
                double x, y, s;

                if (args.Length >= 3 && double.TryParse(args[0], out x) && double.TryParse(args[1], out y) && double.TryParse(args[2], out s))
                {
                    var shape = new Square(x, y, s);
                    Program.Storage.Add(shape);
                    Console.WriteLine("Just added {0}", shape.ToString());
                }
                else
                {
                    Console.WriteLine("Invalid arguments");
                }
            });

            this.Cmds.Add("rectangle", (args) =>
            {
                double x, y, w, h;

                if (args.Length >= 4 && double.TryParse(args[0], out x) && double.TryParse(args[1], out y) && double.TryParse(args[2], out w) && double.TryParse(args[3], out h))
                {
                    var shape = new Rectangle(x, y, w, h);
                    Program.Storage.Add(shape);
                    Console.WriteLine("Just added {0}", shape.ToString());
                }
                else
                {
                    Console.WriteLine("Invalid arguments");
                }
            });

            this.Cmds.Add("triangle", (args) =>
            {
                double x1, x2, x3, y1, y2, y3;

                if (args.Length >= 6 && double.TryParse(args[0], out x1) && double.TryParse(args[1], out y1) && double.TryParse(args[2], out x2) && double.TryParse(args[3], out y2) && double.TryParse(args[4], out x3) && double.TryParse(args[5], out y3))
                {
                    var shape = new Triangle(x1, y1, x2, y2, x3, y3);
                    Program.Storage.Add(shape);
                    Console.WriteLine("Just added {0}", shape.ToString());
                }
                else
                {
                    Console.WriteLine("Invalid arguments");
                }
            });

            this.Cmds.Add("circle", (args) =>
            {
                double x, y, r;

                if (args.Length >= 3 && double.TryParse(args[0], out x) && double.TryParse(args[1], out y) && double.TryParse(args[2], out r))
                {
                    var shape = new Circle(x, y, r);
                    Program.Storage.Add(shape);
                    Console.WriteLine("Just added {0}", shape.ToString());
                }
                else
                {
                    Console.WriteLine("Invalid arguments");
                }
            });

            this.Cmds.Add("donut", (args) =>
            {
                double x, y, r1, r2;

                if (args.Length >= 4 && double.TryParse(args[0], out x) && double.TryParse(args[1], out y) && double.TryParse(args[2], out r1) && double.TryParse(args[3], out r2))
                {
                    var shape = new Donut(x, y, r1, r2);
                    Program.Storage.Add(shape);
                    Console.WriteLine("Just added {0}", shape.ToString());
                }
                else
                {
                    Console.WriteLine("Invalid arguments");
                }
            });

            this.Cmds.Add("squares", (args) =>
            {
                var data = Program.Storage.GetByType<Square>();
                if (data.Any())
                {
                    foreach (var shape in data)
                        Console.WriteLine(shape.ToString());
                }
                else
                {
                    Console.WriteLine("No shapes found");
                }
            });

            this.Cmds.Add("rectangles", (args) =>
            {
                var data = Program.Storage.GetByType<Rectangle>();
                if (data.Any())
                {
                    foreach (var shape in data)
                        Console.WriteLine(shape.ToString());
                }
                else
                {
                    Console.WriteLine("No shapes found");
                }
            });

            this.Cmds.Add("triangles", (args) =>
            {
                var data = Program.Storage.GetByType<Triangle>();
                if (data.Any())
                {
                    foreach (var shape in data)
                        Console.WriteLine(shape.ToString());
                }
                else
                {
                    Console.WriteLine("No shapes found");
                }
            });

            this.Cmds.Add("circles", (args) =>
            {
                var data = Program.Storage.GetByType<Circle>();
                if (data.Any())
                {
                    foreach (var shape in data)
                        Console.WriteLine(shape.ToString());
                }
                else
                {
                    Console.WriteLine("No shapes found");
                }
            });

            this.Cmds.Add("donuts", (args) =>
            {
                var data = Program.Storage.GetByType<Donut>();
                if (data.Any())
                {
                    foreach (var shape in data)
                        Console.WriteLine(shape.ToString());
                }
                else
                {
                    Console.WriteLine("No shapes found");
                }
            });

            this.Cmds.Add("shapes", (args) =>
            {
                var data = Program.Storage.GetWhere(s => true);
                if (data.Any())
                {
                    foreach (var shape in data)
                        Console.WriteLine(shape.ToString());
                }
                else
                {
                    Console.WriteLine("No shapes found");
                }
            });

            this.Cmds.Add("contains", (args) =>
            {
                double x, y;

                if (args.Length >= 2 && double.TryParse(args[0], out x) && double.TryParse(args[1], out y))
                {
                    var point = new Point(x, y);
                    var data = Program.Storage.GetWhere(s => s.Contains(point));
                    Console.WriteLine("Shapes containing ({0}):", point.ToString());
                    foreach (var shape in data)
                    {
                        Console.WriteLine(shape.ToString());
                    }
                    Console.WriteLine("Total area: {0}", data.Sum(s => s.GetArea()));
                }
                else
                {
                    Console.WriteLine("Invalid arguments");
                }
            });

            this.Cmds.Add("cls", (args) =>
            {
                Console.Clear();
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public IStorage ResolveStorage(string[] args)
        {
            IStorage storage = null;

            if (args.Length > 0)
            {
                var firstCommand = args[0];

                if (this.StorageCmds.ContainsKey(firstCommand))
                {
                    var command = this.StorageCmds[firstCommand];
                    var arguments = args.Skip(1).Take(args.Length - 1).ToArray();
                    storage = command(arguments);
                }
            }

            return storage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool Execute(string[] args)
        {
            var execute = true;

            if (args.Length > 0)
            {
                var firstCommand = args[0];

                if (!firstCommand.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (this.Cmds.ContainsKey(firstCommand))
                    {
                        var command = this.Cmds[firstCommand];
                        var arguments = args.Skip(1).Take(args.Length - 1).ToArray();
                        command(arguments);
                    }
                }
                else
                {
                    execute = false;
                }
            }

            return execute;
        }
    }
}
