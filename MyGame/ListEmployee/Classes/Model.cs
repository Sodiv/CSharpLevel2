using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ListEmployee.Classes
{
    class Model
    {
        DataBase dataBase;
        public Model()
        {
            dataBase = new DataBase();
        }
        public object Data()
        {
            return dataBase;
        }
        public Employee Update()
        {
            return dataBase.SelectedEmployee;
        }
        public void Delete()
        {
            dataBase.Delete(dataBase.SelectedEmployee);
        }
        public void Add(string name, string age, string department)
        {
            Employee e = new Employee { Name = name, Age = Convert.ToInt32(age), Department = department };
            dataBase.Add(e);
        }
    }
}
