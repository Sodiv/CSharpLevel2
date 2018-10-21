using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ListEmployee
{
    public class Department : INotifyPropertyChanged
    {
        private int id;
        private string name;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.ID)));
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Name)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
