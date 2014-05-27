using System;
using System.Windows;

namespace DiegoGarcia.ProgrammingExercise.Shapes
{
    /// <summary>
    /// 
    /// </summary>
    internal abstract class Shape : IShape
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        public abstract bool Contains(Point point);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract double GetArea();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("=> shape {0}", this.Id);
        }
    }
}
