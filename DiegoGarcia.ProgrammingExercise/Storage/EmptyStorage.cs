using DiegoGarcia.ProgrammingExercise.Shapes;
using System;
using System.Collections.Generic;

namespace DiegoGarcia.ProgrammingExercise.Storage
{
    /// <summary>
    /// 
    /// </summary>
    public class EmptyStorage : Storage
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
        /// <param name="shape"></param>
        public override void Add(IShape shape)
        {
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Flush()
        {
            return;
        }
    }
}
