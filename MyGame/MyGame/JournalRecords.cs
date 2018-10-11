using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class JournalRecords
    {
        public void RecordsWrite(string msg)
        {
            System.IO.File.WriteAllText("records.dat", msg);
        }
    }
}
