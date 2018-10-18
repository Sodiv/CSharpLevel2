using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ListEmployee
{
    class DepartmentViewModel : INotifyPropertyChanged
    {        
        public DepartmentViewModel(Department model)
        {
            Model = model;
        }

        public Department Model { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
