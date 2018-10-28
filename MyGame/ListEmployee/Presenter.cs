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

        public void DepShow()
        {
            DepartmentWindow departmentWindow = new DepartmentWindow(this);
            departmentWindow.Show();
        }

        public void AddDep()
        {
            Department department = new Department();
            EditDepartmentWindow editDepartmentWindow = new EditDepartmentWindow(department);
            editDepartmentWindow.ShowDialog();
            if (editDepartmentWindow.DialogResult.Value)
            {
                model.Add(editDepartmentWindow.result);
            }
        }

        public void Edit(Department department)
        {
            if (department == null) return;
            EditDepartmentWindow editDepartmentWindow = new EditDepartmentWindow(department);
            editDepartmentWindow.ShowDialog();
            if (editDepartmentWindow.DialogResult.Value)
            {
                model.Edit(department);
            }
        }

        public void Delete(Department department)
        {
            model.DeleteD(Convert.ToInt32(department.Id));
        }
    }
}
