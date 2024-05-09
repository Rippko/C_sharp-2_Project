using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Customer: INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string firstName;
        public string FirstName { 
            get { return firstName; } 
            set { SetValue(ref firstName, value); }
        }
        private string lastName;
        public string LastName { get { return lastName; } set { SetValue(ref lastName, value); } }
        public int Age { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void SetValue<T>(ref T prop, T val, [CallerMemberName]string name = null)
        {
            prop = val;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
