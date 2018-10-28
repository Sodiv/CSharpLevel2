using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ListEmployee
{
    public class Employee : INotifyPropertyChanged
    {
        private string id;
        private string name;
        private string age;
        private string department;
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Id)));
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Name)));
            }
        }
        public string Age
        {
            get { return age; }
            set
            {
                age = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Age)));
            }
        }
        public string Department
        {
            get { return department; }
            set
            {
                department = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Department)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
