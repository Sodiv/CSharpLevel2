using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections;

namespace ListEmployee.Classes
{
    class AEmployees : IEnumerable
    {
        private ObservableCollection<Employee> emp;
        public ObservableCollection<Employee> Emp
        {
            get => this.emp;
            set => this.emp = value;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
