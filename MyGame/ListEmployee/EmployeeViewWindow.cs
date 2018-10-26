using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListEmployee
{
    class EmployeeViewWindow
    {
        public Employee Model { get; set; }
        IEnumerable<Department> departmentView { get; set; }
        public EmployeeViewWindow(Employee e, IEnumerable<Department> departments)
        {
            Model = e;
            departmentView = departments;
        }
    }
}
