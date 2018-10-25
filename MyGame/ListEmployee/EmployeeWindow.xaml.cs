using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ListEmployee
{
    /// <summary>
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public Employee Employee { get; private set; }
        EmployeeContext db = new EmployeeContext();
        IEnumerable<Department> departments;
        IEnumerable<Department> Departments
        {
            get { return departments; }
            set
            {
                departments = value;
            }
        }
        public EmployeeWindow(Employee e)
        {
            InitializeComponent();
            Employee = e;
            db.Departments.Load();
            Departments = db.Departments.Local.ToBindingList();
            DataContext = Employee;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
