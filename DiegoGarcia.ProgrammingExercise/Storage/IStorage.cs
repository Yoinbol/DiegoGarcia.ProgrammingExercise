using DiegoGarcia.ProgrammingExercise.Shapes;
using System;
using System.Collections.Generic;

namespace DiegoGarcia.ProgrammingExercise.Storage
{
    public interface IStorage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        void Load();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shape"></param>
        void Add(IShape shape);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        IShape Get(int key);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TShape"></typeparam>
        /// <returns></returns>
        IEnumerable<IShape> GetByType<TShape>() where TShape : IShape;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<IShape> GetWhere(Func<IShape, bool> predicate);

        /// <summary>
        /// 
        /// </summary>
        void Flush();
    }
}
