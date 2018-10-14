using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    class Program
    {
        static Form form = new Form();
        static void Main(string[] args)
        {
            form.Width = 500;
            form.Height = 300;
            SplashScreen.Init(form);            
            form.Show();
            Application.Run(form);
        }
    }
}
