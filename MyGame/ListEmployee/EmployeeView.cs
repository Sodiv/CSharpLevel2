using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ListEmployee
{
    public class EmployeeView : INotifyPropertyChanged
    {
        #region Старый код
        //public ObservableCollection<Department> departments { get; set; }
        //ObservableCollection<Employee> employees { get; set; }
        //private RelayCommand addCommand;
        //private RelayCommand removeCommand;
        //private RelayCommand addDepCommand;
        //private RelayCommand removeDepCommand;
        //private EmployeeViewModel selectedEmployee;
        //private Department selectedDepartment;
        //public RelayCommand AddCommand
        //{
        //    get
        //    {
        //        return addCommand ??
        //          (addCommand = new RelayCommand(obj =>
        //          {
        //              EmployeeViewModel emp = new EmployeeViewModel(new Employee(), departments);
        //              employeeViewModels.Insert(0, emp);
        //              SelectedEmployee = emp;
        //          }));
        //    }
        //}
        //public RelayCommand RemoveCommand
        //{
        //    get
        //    {
        //        return removeCommand ??
        //          (removeCommand = new RelayCommand(obj =>
        //          {
        //              EmployeeViewModel emp = obj as EmployeeViewModel;
        //              if (emp != null)
        //              {
        //                  employeeViewModels.Remove(emp);
        //              }
        //          },
        //          (obj) => employeeViewModels.Count > 0));
        //    }
        //}        
        //public RelayCommand AddDepCommand
        //{
        //    get
        //    {
        //        return addDepCommand ??
        //          (addDepCommand = new RelayCommand(obj =>
        //          {
        //              Department dep = new Department
        //              {
        //                  ID = departments.Count, Name = ""
        //              };
        //              departments.Insert(0, dep);
        //              SelectedDepartment = dep;
        //          }));

        //    }
        //}
        //public RelayCommand RemoveDepCommand
        //{
        //    get
        //    {
        //        return removeDepCommand ??
        //          (removeDepCommand = new RelayCommand(obj =>
        //          {
        //              Department dep = obj as Department;
        //              if (dep != null)
        //              {
        //                  departments.Remove(dep);
        //              }
        //          },
        //          (obj) => departments.Count > 0));
        //    }
        //}

        //public EmployeeViewModel SelectedEmployee
        //{
        //    get { return selectedEmployee; }
        //    set
        //    {
        //        if (value != selectedEmployee)
        //        {
        //            selectedEmployee = value;
        //            OnPropertyChanged();
        //        }

        //    }
        //}

        //public Department SelectedDepartment
        //{
        //    get { return selectedDepartment; }
        //    set
        //    {
        //        selectedDepartment = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public EmployeeView()
        //{            
        //    departments = new ObservableCollection<Department>
        //    {
        //        new Department{ID=0, Name="Администрация"},
        //        new Department{ID=1, Name="Бухгалтерия"}
        //    };
        //    employees = new ObservableCollection<Employee>
        //    {
        //        new Employee{Name="Дмитрий", Age=34, DepartmentId=0},
        //        new Employee{Name="Юлия", Age=42, DepartmentId=1}
        //    };
        //    EEE();
        //}

        //public void EEE()
        //{
        //    employeeViewModels = new ObservableCollection<EmployeeViewModel>();
        //    foreach (var emp in employees)
        //    {
        //        employeeViewModels.Add(new EmployeeViewModel(emp, departments));
        //    }
        //}
        //public ObservableCollection<EmployeeViewModel> employeeViewModels { get; set; }
        #endregion
        EmployeeContext db;
        RelayCommand addCommand;
        RelayCommand editCommand;
        RelayCommand deleteCommand;
        IEnumerable<Employee> employees;
        public IEnumerable<Employee> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Employees)));
            }
        }
        IEnumerable<Department> departments;
        public IEnumerable<Department> Departments
        {
            get { return departments; }
            set
            {
                departments = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Departments)));
            }
        }
        public EmployeeView()
        {
            #region Заполнение начальными данными
            //Random rnd = new Random();
            //using (db = new EmployeeContext())
            //{
            //    Department dep = new Department { Name = $"dep_{rnd.Next(0,15)}" };
            //    Employee employee = new Employee { Name = $"name_{rnd.Next(0, 25)}", Age = rnd.Next(20, 45), Department = dep };
            //    for (int i = 0; i < 3; i++)
            //    {
            //        db.Departments.Add(dep);
            //        for (int j = 0; j < 5; j++)
            //        {
            //            db.Employees.Add(employee);
            //        }
            //        db.SaveChanges();
            //    }

            //}
            #endregion
            db = new EmployeeContext();
            db.Employees.Load();
            db.Departments.Load();
            Departments = db.Departments.Local.ToBindingList();
            Employees = db.Employees.Local.ToBindingList();
        }
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand((o) =>
                  {
                      EmployeeWindow employeeWindow = new EmployeeWindow(new Employee(), departments);
                      if (employeeWindow.ShowDialog() == true)
                      {
                          Employee employee = employeeWindow.Employee;
                          db.Employees.Add(employee);
                          db.SaveChanges();
                      }
                  }));
            }
        }
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ?? (editCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      Employee employee = selectedItem as Employee;
                      Employee vm = new Employee
                      {
                          Id = employee.Id,
                          Name = employee.Name,
                          Age = employee.Age,
                          Department = employee.Department
                      };
                      EmployeeWindow employeeWindow = new EmployeeWindow(vm, departments);
                      if (employeeWindow.ShowDialog() == true)
                      {
                          employee = db.Employees.Find(employeeWindow.Employee.Id);
                          if (employee != null)
                          {
                              employee.Name = employeeWindow.Employee.Name;
                              employee.Age = employeeWindow.Employee.Age;
                              employee.Department = employeeWindow.Employee.Department;
                              db.Entry(employee).State = EntityState.Modified;
                              db.SaveChanges();
                          }
                      }
                  }));
            }
        }
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ?? (deleteCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      Employee employee = selectedItem as Employee;
                      db.Employees.Remove(employee);
                      db.SaveChanges();
                  }));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
