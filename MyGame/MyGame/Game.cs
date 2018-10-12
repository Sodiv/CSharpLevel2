using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MyGame
{
    delegate void GetArgs(string value);
    class Game
    {
        Form form;
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static BaseObject[] _objs;
        private static Bullet _bullet;
        private static Asteroid[] _asteroids;
        private static Heal _heal;
        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));
        private static Timer _timer = new Timer();
        private int createHeal = 500;
        private static int score = 0;
        public static JournalRecords journalRecords = new JournalRecords();
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
        public void Init(Form form)
        {
            this.form = form;
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            //Width = form.Width;
            //Height = form.Height;
            if (form.Width < 0 || form.Height < 0)
                throw new ArgumentOutOfRangeException("Размер формы", "Меньше минимального значения");
            else if (form.Width > 1000 || form.Height > 1000)
                throw new ArgumentOutOfRangeException("Размер формы", "Больше максимального значения");
            else
            {
                Width = form.Width;
                Height = form.Height;
            }
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            Ship.MessageDie += Finish;
            form.KeyDown += Form_KeyDown;
            this.form.FormClosing += Form_FormClosing;
            _timer = new Timer { Interval = 100 };
            _timer.Start();
            _timer.Tick += Timer_Tick;
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timer.Stop();
        }

        /// <summary>
        /// Обработчик нажатия кнопок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _bullet = new Bullet(new Point(_ship.rect.X + 10, _ship.rect.Y + 4), new Point(4, 0), new Size(4, 1));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }

        /// <summary>
        /// Прорисовка в буфере и вывод на экран
        /// </summary>
        public void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs) obj.Draw();
            foreach (Asteroid ast in _asteroids) ast?.Draw();
            _bullet?.Draw();
            _ship?.Draw();
            _heal?.Draw();
            if (_ship != null)
                Buffer.Graphics.DrawString("Energy: " + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            Buffer.Render();
        }
        /// <summary>
        /// Обновление объектов
        /// </summary>
        public void Update()
        {
            foreach (BaseObject obj in _objs) obj.Update();
            _bullet?.Update();
            _heal?.Update();
            for(int i=0;i<_asteroids.Length;i++)
            {
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();
                if(_bullet!=null && _bullet.Collision(_asteroids[i]))
                {
                    WorkData("Уничтожен астероид", journalRecords.JournalWrite);
                    System.Media.SystemSounds.Hand.Play();
                    _asteroids[i] = null;
                    _bullet = null;
                    score += 1;
                    continue;
                }
                if (_heal != null && _ship.Collision(_heal))
                {
                    WorkData($"Корабль отлечился на {_heal.power} хитов", journalRecords.JournalWrite);
                    _ship.EnergyLow(_heal.power);
                }
                if (!_ship.Collision(_asteroids[i])) continue;
                var rnd = new Random();
                _ship.EnergyLow(rnd.Next(1, 10));
                WorkData("Корабль столкнулся с астероидом и получил урон", journalRecords.JournalWrite);
                System.Media.SystemSounds.Asterisk.Play();
                if (_ship.Energy <= 0) _ship?.Die();
            }
        }
        /// <summary>
        /// Создание массивов для BaseObject
        /// </summary>
        public void Load()
        {
            _objs = new BaseObject[100];
            _asteroids = new Asteroid[3];
            for(int i = 0; i < _objs.Length; i++)
            {
                if (i % 6 == 0)
                {
                    _objs[i] = new Planet(new Point(r.Next(0, r.Next(0, Game.Height)), i*6), new Point(-6, 0), new Size(10, 10));
                }
                else if(i % 3 == 0)
                {
                    _objs[i] = new Star(new Point(r.Next(0, r.Next(0, Game.Height)), i*6), new Point(-3, 0), new Size(5, 5));
                }
                else
                {
                    _objs[i] = new Farstar(new Point(r.Next(0, r.Next(0, Game.Height)), i*6), new Point(-1, 0), new Size(1, 1));
                }
            }
            for (int i = 0; i < _asteroids.Length; i++)
            {
                int a = r.Next(5, 50);
                _asteroids[i] = new Asteroid(new Point(1000, r.Next(0, Game.Height)), new Point(-a / 5, a), new Size(a, a));
            }            
        }
        /// <summary>
        /// Окончание игры
        /// </summary>
        public static void Finish()
        {
            WorkData("Players " + Convert.ToString(score), journalRecords.RecordsWrite);
            WorkData("Игра окончена!", journalRecords.JournalWrite);
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }
        static void WorkData(string msg, GetArgs method)
        {
            method(msg);
        }
        /// <summary>
        /// Конструктор таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {            
            createHeal = createHeal - 1;
            Draw();
            Update();
            if (createHeal == 0)
            {
                _heal = new Heal(new Point(1000, r.Next(0, Game.Height)), new Point(-5, 0), new Size(20, 20));
                createHeal = r.Next(300, 10000);
            }
        }

    }
}
