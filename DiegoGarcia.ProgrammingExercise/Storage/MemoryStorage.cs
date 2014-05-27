using DiegoGarcia.ProgrammingExercise.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiegoGarcia.ProgrammingExercise.Storage
{
    /// <summary>
    /// 
    /// </summary>
    internal class MemoryStorage : IStorage
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<int, IShape> data { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected int Counter { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        internal MemoryStorage()
        {
            this.data = new Dictionary<int, IShape>();
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="shape"></param>
        public void Store(IShape shape)
        {
            var key = ++Counter;
            shape.Id = key;
            this.data.Add(key, shape);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IShape Get(int key)
        {
            return data[key];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TShape"></typeparam>
        /// <returns></returns>
        public IEnumerable<IShape> GetByType<TShape>() where TShape : IShape
        {
            return data.Values.Where(s => s is TShape);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<IShape> GetWhere(Func<IShape, bool> predicate)
        {
            return data.Values.Where(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Load()
        {
            //Memory storage is not persisted. It starts from scratch on every run.
        }
    }
}
