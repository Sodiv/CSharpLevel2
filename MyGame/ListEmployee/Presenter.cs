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
        /// Data Context
        /// </summary>
        /// <returns>Возврат таблицы данных</returns>
        public object Data()
        {
            return null;
        }

        public void Load()
        {
            model.Load();
        }

        public void Dep()
        {
            DepartmentWindow departmentWindow = new DepartmentWindow(this);
            departmentWindow.Show();
        }
    }
}
