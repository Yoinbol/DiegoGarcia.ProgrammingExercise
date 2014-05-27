using DiegoGarcia.ProgrammingExercise.Shapes;
using System;
using System.Collections.Generic;
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
        private Commands()
        {
            ConfigureCommands();
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
                    Program.Storage.Store(shape);
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
                    Program.Storage.Store(shape);
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
                    Program.Storage.Store(shape);
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

                if (args.Length >= 6 && double.TryParse(args[0], out x) && double.TryParse(args[1], out y) && double.TryParse(args[2], out r))
                {
                    var shape = new Circle(x, y, r);
                    Program.Storage.Store(shape);
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

                if (args.Length >= 6 && double.TryParse(args[0], out x) && double.TryParse(args[1], out y) && double.TryParse(args[2], out r1) && double.TryParse(args[3], out r2))
                {
                    var shape = new Donut(x, y, r1, r2);
                    Program.Storage.Store(shape);
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
