using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ListEmployee
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public EmployeeViewModel(Employee model, ObservableCollection<Department> departments)
        {
            Model = model;
            departmentViewModels = new ObservableCollection<DepartmentViewModel>();
            foreach (var dep in departments)
            {
                departmentViewModels.Add(new DepartmentViewModel(dep));
            }
        }
        public Employee Model { get; set; }
        public ObservableCollection<DepartmentViewModel> departmentViewModels { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
