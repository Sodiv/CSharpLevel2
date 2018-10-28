using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListEmployee
{
    public class Presenter
    {
        public Model model;

        public Presenter()
        {
            model = new Model();
            
        }
        /// <summary>
        /// Загрузка данных
        /// </summary>
        public void Load()
        {
            model.Load();
        }

        public void Add()
        {
            Employee employee = new Employee();
            EditEmployeeWindow editEmployeeWindow = new EditEmployeeWindow(employee);
            editEmployeeWindow.ShowDialog();
            if (editEmployeeWindow.DialogResult.Value)
            {
                model.Add(editEmployeeWindow.resultRow);
            }
        }

        public void Edit(Employee employee)
        {
            if (employee == null) return;
            EditEmployeeWindow editEmployeeWindow = new EditEmployeeWindow(employee);
            editEmployeeWindow.ShowDialog();
            if (editEmployeeWindow.DialogResult.Value)
            {
                model.Edit(employee);
            }            
        }

        public void Delete(Employee employee)
        {
            model.Delete(Convert.ToInt32(employee.Id));
        }

        public void Dep()
        {
            DepartmentWindow departmentWindow = new DepartmentWindow(this);
            departmentWindow.Show();
        }
    }
}
