using System.Windows;

namespace DiegoGarcia.ProgrammingExercise.Shapes
{
    /// <summary>
    /// 
    /// </summary>
    internal interface IShape
    {
        /// <summary>
        /// 
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        bool Contains(Point point);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        double GetArea();
    }
}
