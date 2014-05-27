using DiegoGarcia.ProgrammingExercise.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoGarcia.ProgrammingExercise.Storage
{
    internal interface IStorage
    {
        /// <summary>
        /// 
        /// </summary>
        void Load();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shape"></param>
        void Store(IShape shape);

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
    }
}
