using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    class SplashScreen
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Label[] lbl = new Label[3];

        public static void Init(Form form)
        {
            Game.Init(form);
            Game.Draw();
            Width = form.Width;
            Height = form.Height;
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

        private static void SplashScreen_Click(object sender, EventArgs e)
        {
            int i = (int)(sender as Label).Tag;
            if (i == 0)
            {
                Form form = new Form();
                //{
                //    Width = Screen.PrimaryScreen.Bounds.Width,
                //    Height = Screen.PrimaryScreen.Bounds.Height
                //};
                form.Width = 800;
                form.Height = 600;
                Game.Init(form);
                form.ShowDialog();
                Game.Load();
                Game.Draw();
            }
            if (i == 2)
            {
                Program.Close();
            }
        }
    }
}
