using DiegoGarcia.ProgrammingExercise.Shapes;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace DiegoGarcia.ProgrammingExercise.Storage
{
    /// <summary>
    /// 
    /// </summary>
    public class JsonFileStorage : FileStorage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public JsonFileStorage(string path)
            : base(path)
        { 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override void Load()
        {
            var fileContent = File.ReadAllText(this.Path);
            var data = new JavaScriptSerializer().Deserialize<List<Dictionary<string, dynamic>>>(fileContent);

            foreach (var row in data)
            {
                var shape = ParseShape(row);

                if (shape != null && !this.data.ContainsKey(shape.Id))
                {
                    this.data.Add(shape.Id, shape);
                    this.Index = Math.Max(Index, shape.Id);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
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
            var serializer = new JavaScriptSerializer();
            var content = serializer.Serialize(this.data.Values.Select(i => i));
            File.WriteAllText(this.Path, content);
        }
    }
}
