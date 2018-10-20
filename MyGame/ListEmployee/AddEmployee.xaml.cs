﻿using System;
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
using System.Windows.Shapes;
using ListEmployee.Classes;

namespace ListEmployee
{
    /// <summary>
    /// Логика взаимодействия для WindowEmployees.xaml
    /// </summary>
    public partial class AddEmployees : Window
    {        
        public AddEmployees(Presenter p)
        {
            InitializeComponent();
            btAdd.Click += delegate { p.Add(tbName.Text, tbAge.Text, tbDepartment.Text); Close(); };
        }
    }
}
