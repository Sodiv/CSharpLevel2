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
        public EmployeeViewModel(Employee model, IEnumerable<Department> departments)
        {
            Model = model;
            var departmentViewModel = new List<DepartmentViewModel>();
            foreach (var dep in departments)
            {
                departmentViewModel.Add(new DepartmentViewModel(dep));
            }
            departmentViewModels = departmentViewModel;
        }
        public Employee Model { get; set; }
        public IEnumerable<DepartmentViewModel> departmentViewModels { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
