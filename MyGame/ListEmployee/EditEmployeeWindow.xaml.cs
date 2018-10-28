﻿using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для EditEmployeeWindow.xaml
    /// </summary>
    public partial class EditEmployeeWindow : Window
    {
        public DataRow resultRow { get; set; }
        public EditEmployeeWindow(DataRow dataRow, Presenter p)
        {
            InitializeComponent();
            resultRow = dataRow;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            nameTextBox.Text = resultRow["Name"].ToString();
            ageTextBox.Text = resultRow["Age"].ToString();
            departmentTextBox.Text = resultRow["Department"].ToString();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            resultRow["Name"] = nameTextBox.Text;
            resultRow["Age"] = ageTextBox.Text;
            resultRow["Department"] = departmentTextBox.Text;
            this.DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}