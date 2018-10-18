using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListEmployee
{
    class EmployeeView
    {
        ObservableCollection<Department> departments { get; set; }
        ObservableCollection<Employee> employees { get; set; }
        private EmployeeViewModel selectedEmployee;

        public EmployeeViewModel SelectedEmployee
        {
            get { return selectedEmployee; }
            set { selectedEmployee = value; }
        }

        public EmployeeView()
        {
            departments = new ObservableCollection<Department>
            {
                new Department{ID=0, Name="Администрация"},
                new Department{ID=1, Name="Бухгалтерия"}
            };
            employees = new ObservableCollection<Employee>
            {
                new Employee{Name="Дмитрий", Age=34, DepartmentId=0},
                new Employee{Name="Юлия", Age=42, DepartmentId=1}
            };
            var employeeViewModel = new List<EmployeeViewModel>();
            foreach(var emp in employees)
            {
                employeeViewModel.Add(new EmployeeViewModel(emp, departments));
            }
            employeeViewModels = employeeViewModel;
        }
        public IEnumerable<EmployeeViewModel> employeeViewModels { get; set; }
    }
}
