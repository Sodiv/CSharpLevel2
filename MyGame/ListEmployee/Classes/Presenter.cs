using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ListEmployee.Classes
{
    public class Presenter
    {
        Model model;
        public Presenter()
        {
            model = new Model();
        }
        public object Data()
        {
            return model.Data();
        }
        public void Add()
        {
            AddEmployees window = new AddEmployees(this);
            window.Show();
        }
        public void Add(string name, string age, string department)
        {
            if (name != "")
            {
                model.Add(name, age, department);
            }
        }
        public void Update()
        {
            WindowEmployees window = new WindowEmployees(this);
            window.Show();
        }
        public void Delete()
        {
            model.Delete();
        }
    }
}
