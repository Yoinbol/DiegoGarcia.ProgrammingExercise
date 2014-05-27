using DiegoGarcia.ProgrammingExercise.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiegoGarcia.ProgrammingExercise.Storage
{
    public abstract class Storage : IStorage
    {
        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<int, IShape> data { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected int Index { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Storage()
        {
            this.data = new Dictionary<int, IShape>();
        }

        #region Abstract functions

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract void Load();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shape"></param>
        public abstract void Add(IShape shape);

        /// <summary>
        /// 
        /// </summary>
        public abstract void Flush();

        #endregion

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
        /// <param name="data"></param>
        /// <returns></returns>
        protected IShape ParseShape(Dictionary<string, dynamic> data)
        {
            IShape shape = null;

            try
            {
                if (data.ContainsKey("Size"))
                {
                    shape = new Square((double)data["X"], (double)data["Y"], (double)data["Size"]) { Id = (int)data["Id"] };
                }
                else
                {
                    if (data.ContainsKey("Width"))
                    {
                        shape = new Rectangle((double)data["X"], (double)data["Y"], (double)data["Width"], (double)data["Height"]) { Id = (int)data["Id"] };
                    }
                    else
                    {
                        if (data.ContainsKey("X1"))
                        {
                            shape = new Triangle((double)data["X1"], (double)data["Y1"], (double)data["X2"], (double)data["Y2"], (double)data["X3"], (double)data["Y3"]) { Id = (int)data["Id"] };
                        }
                        else
                        {
                            if (data.ContainsKey("Radius"))
                            {
                                shape = new Circle((double)data["X"], (double)data["Y"], (double)data["Radius"]) { Id = (int)data["Id"] };
                            }
                            else
                            {
                                if (data.ContainsKey("Radius1"))
                                {
                                    shape = new Donut((double)data["X"], (double)data["Y"], (double)data["Radius1"], (double)data["Radius2"]) { Id = (int)data["Id"] };
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error parsing shape: {0}", ex.Message);
            }

            return shape;
        }
    }
}
