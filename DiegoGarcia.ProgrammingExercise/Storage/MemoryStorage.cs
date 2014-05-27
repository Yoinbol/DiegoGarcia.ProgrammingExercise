using DiegoGarcia.ProgrammingExercise.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiegoGarcia.ProgrammingExercise.Storage
{
    /// <summary>
    /// 
    /// </summary>
    public class MemoryStorage : Storage, IStorage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override void Load()
        {
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="shape"></param>
        public override void Add(IShape shape)
        {
            var index = ++Index;
            shape.Id = index;
            this.data.Add(index, shape);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Flush()
        {
            //Memory storage does not persist anything
            return;
        }
    }
}
