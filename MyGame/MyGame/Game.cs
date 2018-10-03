using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MyGame
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static BaseObject[] _objs;
        public static Random r = new Random();
        //Свойства
        //Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game() { }
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        public static void Draw()
        {
            //Проверяем вывод графики
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs) obj.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs) obj.Update();
        }

        public static void Load()
        {
            _objs = new BaseObject[100];
            for(int i = 0; i < _objs.Length; i++)
            {
                if (i % 6 == 0)
                {
                    _objs[i] = new BaseObject(new Point(r.Next(0, 800), i*6), new Point(-6, 0), new Size(10, 10));
                }
                else if(i % 3 == 0)
                {
                    _objs[i] = new Star(new Point(r.Next(0, 800), i*6), new Point(-3, 0), new Size(5, 5));
                }
                else
                {
                    _objs[i] = new Farstar(new Point(r.Next(0, 800), i*6), new Point(-1, 0), new Size(1, 1));
                }
            }
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}
