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
        public Employee Employee { get; set; }
        EmployeeViewWindow emp { get; set; }
        public EmployeeWindow(Employee e, IEnumerable<Department> dep)
        {
            InitializeComponent();
            emp = new EmployeeViewWindow(e, dep);
            DataContext = emp;
            Employee = emp.Model;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
