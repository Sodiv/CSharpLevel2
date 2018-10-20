using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListEmployee.Classes
{
    interface IView
    {
        string FirstName { get; set; }
        string Age { get; set; }
        string Department { get; set; }
    }
}
