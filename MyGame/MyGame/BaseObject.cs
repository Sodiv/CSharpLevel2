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
        public BaseObject(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }
        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, pos.X, pos.Y, size.Width, size.Height);
        }
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
