using DiegoGarcia.ProgrammingExercise.Shapes;
using System;
using System.Collections.Generic;

namespace DiegoGarcia.ProgrammingExercise.Storage
{
    /// <summary>
    /// 
    /// </summary>
    public class XmlFileStorage : FileStorage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public XmlFileStorage(string path)
            : base(path)
        { 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override void Load()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shape"></param>
        public override void Add(IShape shape)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Flush()
        {
            throw new NotImplementedException();
        }
    }
}
