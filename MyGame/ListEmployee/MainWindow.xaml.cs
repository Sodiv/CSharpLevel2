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
using System.Data;

namespace ListEmployee
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Presenter p;
        public MainWindow()
        {
            InitializeComponent();
            p = new Presenter();
            DataContext = p.model;
            btnAdd.Click += delegate { p.Add(); };
            btnUpdate.Click += delegate { p.Edit(p.model.SelectedEmployee); };
            btnRemove.Click += delegate { p.Delete(p.model.SelectedEmployee); };
            btnAddDep.Click += delegate { p.AddDep(); };
            btnEditDep.Click += delegate { p.Edit(p.model.SelectedDepartment); };
            btnRemoveDep.Click += delegate { p.Delete(p.model.SelectedDepartment); };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            p.Load();
        }
    }
}
