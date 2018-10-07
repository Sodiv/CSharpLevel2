using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MyGame
{
    class Game
    {        
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static BaseObject[] _objs;
        private static Bullet _bullet;
        private static Asteroid[] _asteroids;
        public static Random r = new Random();
        public static int Width { get; set; }
        public static int Height { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        static Game() { }
        /// <summary>
        /// Конструктор прорисовки фона
        /// </summary>
        /// <param name="form">Форма для прорисовки</param>
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
        /// <summary>
        /// Прорисовка в буфере и вывод на экран
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs) obj.Draw();
            foreach (BaseObject ast in _asteroids) ast.Draw();
            _bullet.Draw();
            Buffer.Render();
        }
        /// <summary>
        /// Обновление объектов
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs) obj.Update();
            foreach (BaseObject ast in _asteroids) ast.Update();
            _bullet.Update();
        }
        /// <summary>
        /// Создание массивов для BaseObject
        /// </summary>
        public static void Load()
        {
            _objs = new BaseObject[100];
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            _asteroids = new Asteroid[3];
            for(int i = 0; i < _objs.Length; i++)
            {
                if (i % 6 == 0)
                {
                    _objs[i] = new Planet(new Point(r.Next(0, 800), i*6), new Point(-6, 0), new Size(10, 10));
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
            for (int i = 0; i < _asteroids.Length; i++)
            {
                int a = r.Next(5, 50);
                _asteroids[i] = new Asteroid(new Point(1000, r.Next(0, Game.Height)), new Point(-a / 5, a), new Size(a, a));
            }
        }
        /// <summary>
        /// Конструктор таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}
