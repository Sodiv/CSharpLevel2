using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace ListEmployee
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeView employeeView = new EmployeeView();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = employeeView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee window = new AddEmployee();
            window.employeeView = employeeView;
            window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddDepartment window = new AddDepartment();
            window.employeeView = employeeView;
            window.Show();
        }
    }
}
