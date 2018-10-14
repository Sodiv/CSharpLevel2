using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyGame
{
    class SplashScreen
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static BaseObject[] _objs;
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static Random r = new Random();
        static Label[] lbl = new Label[3];

        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.Width;
            Height = form.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
            for (int i = 0; i < lbl.Length; i++)
            {
                lbl[i] = new Label() {
                    Left = Width - 300,
                    Top = 100 + i * 25,
                    Tag = i
                };
                switch (i)
                {
                    case 0:
                        lbl[i].Text = "Новая игра";
                        break;
                    case 1:
                        lbl[i].Text = "Рекорды";
                        break;
                    case 2:
                        lbl[i].Text = "Выход";
                        break;
                }
                form.Controls.Add(lbl[i]);
                lbl[i].Click += SplashScreen_Click;
            }
        }
        public static void Draw()
        {
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
            _objs = new BaseObject[50];
            for (int i = 0; i < _objs.Length; i++)
            {
                _objs[i] = new StarsScreen(new Point(r.Next(0, r.Next(0, SplashScreen.Height)), i * 6), new Point(-3, 0), new Size(3, 5));
            }
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        /// <summary>
        /// Обработка нажатия кнопок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void SplashScreen_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            int i = (int)(sender as Label).Tag;
            if (i == 0)
            {
                Form form = new Form();
                //{
                //    Width = Screen.PrimaryScreen.Bounds.Width,
                //    Height = Screen.PrimaryScreen.Bounds.Height
                //};
                form.Width = 1000;
                form.Height = 600;
                try
                {
                    game.Init(form);
                } catch(ArgumentOutOfRangeException outOfRange)
                {
                    Console.WriteLine($"Error: {outOfRange}");
                }
                form.ShowDialog();                
                //game.Load();
                //game.Draw();                
            }
            if (i == 2)
            {
                Application.Exit();
            }
        }
    }
}
