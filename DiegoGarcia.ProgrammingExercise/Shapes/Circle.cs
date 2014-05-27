using System;
using System.Windows;

namespace DiegoGarcia.ProgrammingExercise.Shapes
{
    /// <summary>
    /// 
    /// </summary>
    internal class Circle : Shape
    {
        /// <summary>
        /// 
        /// </summary>
        public Point Center { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        public Circle(double x, double y, double radius)
        { 
            this.Center = new Point(x, y);
            this.Radius = radius;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        public Circle(Point center, double radius)
        {
            this.Center = center;
            this.Radius = radius;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var circle = string.Format("circle with centre at ({0}, {1}) and radius {2}", Center.X, Center.Y, Radius);

            return string.Format("{0}: {1}", base.ToString(), circle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public override bool Contains(Point point)
        {
            return this.Center.Distance(point) <= this.Radius;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override double GetArea()
        {
            return Radius * Radius * Math.PI;
        }
    }
}
