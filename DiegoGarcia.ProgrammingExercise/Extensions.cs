using System;
using System.Windows;

namespace DiegoGarcia.ProgrammingExercise
{
    /// <summary>
    /// 
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        internal static double Distance(this Point instance, Point point)
        {
            double a = instance.X - point.X;
            double b = instance.Y - point.Y;
            return Math.Sqrt(a * a + b * b);
        }
    }
}
