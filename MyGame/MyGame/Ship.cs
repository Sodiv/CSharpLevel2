using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class Ship : BaseObject
    {
        public static event Message MessageDie;
        private int _energy = 100;
        public int Energy => _energy;

        public void EnergyLow(int n)
        {
            _energy -= n;
        }

        public Ship(Point pos,Point dir,Size size) : base(pos, dir, size) { }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, pos.X, pos.Y, size.Width, size.Height);
        }

        public override void Update()
        {
            
        }
        /// <summary>
        /// Кончтруктор обработки кнопки Вверх
        /// </summary>
        public void Up()
        {
            if (pos.Y > 0) pos.Y = pos.Y - dir.Y;
        }
        /// <summary>
        /// Кончтруктор обработки кнопки Вниз
        /// </summary>
        public void Down()
        {
            if (pos.Y < Game.Height) pos.Y = pos.Y + dir.Y;
        }
        public void Die()
        {
            MessageDie?.Invoke();
        }
    }
}
