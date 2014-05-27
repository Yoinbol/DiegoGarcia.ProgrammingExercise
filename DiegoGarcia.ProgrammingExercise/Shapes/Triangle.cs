using System;
using System.Windows;

namespace DiegoGarcia.ProgrammingExercise.Shapes
{
    internal class Triangle : Shape
    {
        /// <summary>
        /// 
        /// </summary>
        protected Point[] Points { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.Points = new [] 
            {
                new Point(x1, y1),
                new Point(x2, y2),
                new Point(x3, y3)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var triangle = string.Format("triangle ({0}, {1}), ({2}, {3}), ({4}, {5})", Points[0].X, Points[0].Y, Points[1].X, Points[1].Y, Points[2].X, Points[2].Y);

            return string.Format("{0}: {1}", base.ToString(), triangle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public override bool Contains(Point point)
        {
            var denominator = ((Points[1].Y - Points[2].Y)*(Points[0].X - Points[2].X) + (Points[2].X - Points[1].X)*(Points[0].Y - Points[2].Y));
            var a = ((Points[1].Y - Points[2].Y)*(point.X - Points[2].X) + (Points[2].X - Points[1].X)*(point.Y - Points[2].Y)) / denominator;
            var b = ((Points[2].Y - Points[0].Y)*(point.X - Points[2].X) + (Points[0].X - Points[2].X)*(point.Y - Points[2].Y)) / denominator;
            var c = 1 - a - b;
            return 0 <= a && a <= 1 && 0 <= b && b <= 1 && 0 <= c && c <= 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override double GetArea()
        {
            var A = Math.Sqrt((Points[1].X - Points[0].X) * (Points[1].X - Points[0].X) + (Points[1].Y - Points[0].Y) * (Points[1].Y - Points[1].Y));
            var B = Math.Sqrt((Points[1].X - Points[2].X) * (Points[1].X - Points[2].X) + (Points[1].Y - Points[2].Y) * (Points[1].Y - Points[2].Y));
            var C = Math.Sqrt((Points[0].X - Points[2].X) * (Points[0].X - Points[2].X) + (Points[0].Y - Points[2].Y) * (Points[0].Y - Points[2].Y));
            var s = (A + B + C) / 2;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }
    }
}
