using DiegoGarcia.ProgrammingExercise.Shapes;
using System;
using System.Collections.Generic;

namespace DiegoGarcia.ProgrammingExercise.Storage
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class FileStorage : Storage
    {
        /// <summary>
        /// 
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public FileStorage(string path)
        {
            this.Path = path;
        }
    }
}
