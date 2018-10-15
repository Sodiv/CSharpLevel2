using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {        
        static void Main(string[] args)
        {
            /*Дана коллекция List<T>. 
             * Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции*/
            Random rnd = new Random();
            List<int> vs = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                vs.Add(rnd.Next(2, 10));
            }
            // для целых чисел
            foreach(int val in vs.Distinct())
            {
                Console.WriteLine(val + " - " + vs.Where(x => x == val).Count() + " раз");
            }
            Console.ReadKey();
            // с помощью LINQ
            
        }
    }
}
