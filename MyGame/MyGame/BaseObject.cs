using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class BaseObject
    {
        protected Point pos;
        protected Point dir;
        protected Size size;
        public static Random r = new Random();
        Image image = Image.FromFile("../../Img/planet.png");
        /// <summary>
        /// Конструктор базового объекта
        /// </summary>
        /// <param name="pos">Координаты объекта на экране</param>
        /// <param name="dir">Направление смещения</param>
        /// <param name="size">Размер объекта</param>
        public BaseObject(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }
        /// <summary>
        /// Прорисовка объекта
        /// </summary>
        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, pos.X, pos.Y, size.Width, size.Height);
        }
        /// <summary>
        /// Обновление расположения (движение) объекта
        /// </summary>
        public void Update()
        {
            pos.X = pos.X + dir.X;
            if (pos.X < 0)
            {
                pos.X = Game.Width + size.Width;
                pos.Y = r.Next(0, 600);
            }
        }
    }
}
