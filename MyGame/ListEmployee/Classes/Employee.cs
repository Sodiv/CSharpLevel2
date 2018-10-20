using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ListEmployee.Classes
{
    public class Employee : INotifyPropertyChanged
    {
        private string name;
        private int age;
        private string department;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Name)));
            }
        }

        public int Age
        {
            get => age;
            set
            {
                age = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Age)));
            }
        }

        public string Department
        {
            get => department;
            set
            {
                department = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Department)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
