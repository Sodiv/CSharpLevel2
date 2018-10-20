using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections;

namespace ListEmployee.Classes
{
    class DataBase
    {
        public static ObservableCollection<Employee> employees { get; set; }
        public static ObservableCollection<Dep> departments { get; set; }
        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get; set;
        }
        static DataBase()
        {
            departments = new ObservableCollection<Dep>
            {
                new Dep{Name="Администрация"},
                new Dep{Name="Бухгалтерия"}
            };
            employees = new ObservableCollection<Employee>
            {
                new Employee{Name="Дмитрий", Age=34, Department="Администрация"},
                new Employee{Name="Юлия", Age=42, Department="Бухгалтерия"}
            };
        }
        public void Delete(Employee e)
        {
            employees.Remove(e);
        }
        public void Add(Employee e)
        {
            employees.Add(e);
        }
    }
}
