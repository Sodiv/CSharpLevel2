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
        private RelayCommand addCommand;
        private RelayCommand removeCommand;
        private RelayCommand addDepCommand;
        private RelayCommand removeDepCommand;
        private EmployeeViewModel selectedEmployee;
        private Department selectedDepartment;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      EmployeeViewModel emp = new EmployeeViewModel(new Employee(), departments);
                      employeeViewModels.Insert(0, emp);
                      SelectedEmployee = emp;
                  }));
            }
        }
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      EmployeeViewModel emp = obj as EmployeeViewModel;
                      if (emp != null)
                      {
                          employeeViewModels.Remove(emp);
                      }
                  },
                  (obj) => employeeViewModels.Count > 0));
            }
        }        
        public RelayCommand AddDepCommand
        {
            get
            {
                return addDepCommand ??
                  (addDepCommand = new RelayCommand(obj =>
                  {
                      Department dep = new Department
                      {
                          ID = departments.Count, Name = ""
                      };
                      departments.Insert(0, dep);
                      SelectedDepartment = dep;
                  }));
                
            }
        }
        public RelayCommand RemoveDepCommand
        {
            get
            {
                return removeDepCommand ??
                  (removeDepCommand = new RelayCommand(obj =>
                  {
                      Department dep = obj as Department;
                      if (dep != null)
                      {
                          departments.Remove(dep);
                      }
                  },
                  (obj) => departments.Count > 0));
            }
        }

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

        public Department SelectedDepartment
        {
            get { return selectedDepartment; }
            set
            {
                selectedDepartment = value;
                OnPropertyChanged();
            }
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
            employeeViewModels = new ObservableCollection<EmployeeViewModel>();
            foreach (var emp in employees)
            {
                employeeViewModels.Add(new EmployeeViewModel(emp, departments));
            }
        }
        public ObservableCollection<EmployeeViewModel> employeeViewModels { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
