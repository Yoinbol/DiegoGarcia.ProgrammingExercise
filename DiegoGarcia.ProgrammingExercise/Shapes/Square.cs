namespace DiegoGarcia.ProgrammingExercise.Shapes
{
    /// <summary>
    /// 
    /// </summary>
    internal class Square : Rectangle
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="size"></param>
        public Square(double x, double y, double size)
            : base(x, y, size, size)
        { 
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
    }
}
