using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyGame
{
    class JournalRecords
    {
        public void RecordsWrite(string msg)
        {
            File.WriteAllText("records.dat", msg);
        }
        public void JournalWrite(string msg)
        {
            Console.WriteLine(msg);
            //File.WriteAllText("journal.dat", msg);
            StreamWriter writer = new StreamWriter("journal.dat", true);
            writer.WriteLine(msg);
            writer.Close();
        }
    }
}
