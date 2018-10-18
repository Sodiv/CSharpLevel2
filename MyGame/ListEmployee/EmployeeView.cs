using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ListEmployee
{
    public class EmployeeView : INotifyPropertyChanged
    {
        public ObservableCollection<Department> departments { get; set; }
        ObservableCollection<Employee> employees { get; set; }
        private EmployeeViewModel selectedEmployee;

        public EmployeeViewModel SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                if (value != selectedEmployee)
                {
                    selectedEmployee = value;
                    OnPropertyChanged();
                }
                
            }
        }

        public void AddEmployee(string name, int age, int departmentId)
        {
            Employee employee = new Employee { Name = name, Age = age, DepartmentId = departmentId };
            employees.Add(employee);
            EEE();
        }

        public void AddDepartment(string name)
        {
            int i = departments.Count();
            departments.Add(new Department { ID = i, Name = name });
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
            EEE();
        }

        public void EEE()
        {
            var employeeViewModel = new List<EmployeeViewModel>();
            foreach (var emp in employees)
            {
                employeeViewModel.Add(new EmployeeViewModel(emp, departments));
            }
            employeeViewModels = employeeViewModel;
        }
        public IEnumerable<EmployeeViewModel> employeeViewModels { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
