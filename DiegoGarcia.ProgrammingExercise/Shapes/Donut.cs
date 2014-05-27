using System;
using System.Windows;

namespace DiegoGarcia.ProgrammingExercise.Shapes
{
    /// <summary>
    /// 
    /// </summary>
    internal class Donut : Shape
    {
        /// <summary>
        /// 
        /// </summary>
        public Point Center { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Radius1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Radius2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius1">Inner radius</param>
        /// <param name="radius2">External radius</param>
        public Donut(double x, double y, double radius1, double radius2)
        { 
            this.Center = new Point(x, y);

            if (radius1 > radius2)
            {
                this.Radius2 = radius1;
                this.Radius1= radius2;
            }
            else
            {
                this.Radius1 = radius1;
                this.Radius2 = radius2;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var donut = string.Format("donut with centre at ({0}, {1}), radius1 {2} and radius2 {3}", Center.X, Center.Y, Radius1, Radius2);

            return string.Format("{0}: {1}", base.ToString(), donut);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public override bool Contains(Point point)
        {
            var externalCircle = new Circle(Center, Radius1);
            var internalCircle = new Circle(Center, Radius2);
            return externalCircle.Contains(point) && !internalCircle.Contains(point);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override double GetArea()
        {
            var totalArea = Radius2 * Radius2 * Math.PI;
            var innerArea = Radius1 * Radius1 * Math.PI;
            return totalArea - innerArea;
        }
    }
}
