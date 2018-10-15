using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Дан фрагмент программы
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four", 4 },
                {"two", 2 },
                {"one", 1 },
                {"three", 3 }
            };
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            Console.ReadKey();
            //Свернуть обращение к OrderBy с использованием лямбда
            var l = dict.OrderBy(pair => pair.Value);
            foreach (var pair in l)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
            Console.ReadKey();
        }
    }
}
