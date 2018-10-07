using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    abstract class BaseObject
    {
        protected Point pos;
        protected Point dir;
        protected Size size;
        public static Random r = new Random();
        
        /// <summary>
        /// Конструктор базового объекта
        /// </summary>
        /// <param name="pos">Координаты объекта на экране</param>
        /// <param name="dir">Направление смещения</param>
        /// <param name="size">Размер объекта</param>
        protected BaseObject(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }
        /// <summary>
        /// Прорисовка объекта
        /// </summary>
        public abstract void Draw();
        /// <summary>
        /// Обновление расположения (движение) объекта
        /// </summary>
        public abstract void Update();
    }
}
