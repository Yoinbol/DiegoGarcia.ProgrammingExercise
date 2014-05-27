using System;
using System.Windows;

namespace DiegoGarcia.ProgrammingExercise.Shapes
{
    /// <summary>
    /// 
    /// </summary>
    internal class Rectangle : Shape
    {
        /// <summary>
        /// 
        /// </summary>
        protected Rect Rect { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public Rectangle(double x, double y, double width, double height)
        {
            this.Rect = new Rect(new Point(x, y), new Size(width, height));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var rectangle = string.Format("Rectangle with corner at ({0}, {1}), width {2} and height {3}", this.Rect.X, this.Rect.Y, this.Rect.Size.Width, this.Rect.Size.Height);

            return string.Format("{0}: {1}", base.ToString(), rectangle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public override bool Contains(Point point)
        {
            return this.Rect.Contains(point);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override double GetArea()
        {
            return this.Rect.Size.Height * this.Rect.Size.Width;
        }
    }
}
