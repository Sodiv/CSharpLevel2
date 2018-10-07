using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    interface ICollision
    {
        /// <summary>
        /// Интерфейс обработки столкновений
        /// </summary>
        /// <param name="obj">Объект проверки</param>
        /// <returns>Столкнулся?</returns>
        bool Collision(ICollision obj);
        Rectangle rect { get; }
    }
}
