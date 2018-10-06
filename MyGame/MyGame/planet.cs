using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Planet : BaseObject
    {
        Image image = Image.FromFile("../../Img/planet.png");
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Planet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        /// <summary>
        /// Прорисовка планет
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, pos.X, pos.Y, size.Width, size.Height);
        }
    }
}
