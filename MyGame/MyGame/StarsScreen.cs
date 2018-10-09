using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class StarsScreen : BaseObject
    {
        /// <summary>
        /// Конструктор звезды
        /// </summary>
        //// <param name="pos">Координаты объекта на экране</param>
        /// <param name="dir">Направление смещения</param>
        /// <param name="size">Размер объекта</param>
        public StarsScreen(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawLine(Pens.Wheat, pos.X, pos.Y, pos.X + size.Width, pos.Y + size.Height);
            SplashScreen.Buffer.Graphics.DrawLine(Pens.White, pos.X + size.Width, pos.Y, pos.X, pos.Y + size.Height);
        }

        public override void Update()
        {
            pos.X = pos.X + dir.X;
            if (pos.X < 0)
            {
                pos.X = SplashScreen.Width + size.Width;
                pos.Y = r.Next(0, 600);
            }
        }
    }
}
