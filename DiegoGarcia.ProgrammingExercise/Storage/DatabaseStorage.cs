using System;
using System.Collections.Generic;

namespace DiegoGarcia.ProgrammingExercise.Storage
{
    /// <summary>
    /// 
    /// </summary>
    internal class DatabaseStorage : IStorage
    {
        /// <summary>
        /// 
        /// </summary>
        public void Load()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shape"></param>
        public void Store(Shapes.IShape shape)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Shapes.IShape Get(int key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TShape"></typeparam>
        /// <returns></returns>
        public IEnumerable<Shapes.IShape> GetByType<TShape>() where TShape : Shapes.IShape
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<Shapes.IShape> GetWhere(Func<Shapes.IShape, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
