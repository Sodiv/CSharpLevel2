using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class Heal : Asteroid
    {        
        public Heal(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            power = -5;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Red, pos.X, pos.Y, size.Width, size.Height);
        }

        public override void Update()
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
