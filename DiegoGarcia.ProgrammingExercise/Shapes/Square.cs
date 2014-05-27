using System.Windows;
namespace DiegoGarcia.ProgrammingExercise.Shapes
{
    /// <summary>
    /// 
    /// </summary>
    internal class Square : Shape
    {
        /// <summary>
        /// 
        /// </summary>
        public double Size 
        {
            get 
            {
                return this.Rect.Width;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double X
        {
            get
            {
                return this.Rect.X;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double Y
        {
            get
            {
                return this.Rect.Y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected Rect Rect { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="size"></param>
        public Square(double x, double y, double size)
        {
            this.Rect = new Rect(new Point(x, y), new Size(size, size));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var square = string.Format("Square with corner at ({0}, {1}) and side {2}", this.Rect.X, this.Rect.Y, this.Rect.Size.Height);

            return string.Format("=> shape {0}: {1}", Id, square);
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
