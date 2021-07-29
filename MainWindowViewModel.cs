using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_leson11
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            Organizations = new ObservableCollection<Organization>();
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private decimal _salary;

        public decimal Salary
        {
            get { return _salary; }
            set
            {
                _salary = value;
                OnPropertyChanged("Salary");
            }
        }

        public ObservableCollection<Essence> ListEmployee = new ObservableCollection<Essence>();

        public ObservableCollection<Organization> Organizations;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
