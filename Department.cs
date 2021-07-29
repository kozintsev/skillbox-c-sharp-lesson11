using System.Collections.ObjectModel;

namespace test_leson11
{
    public class Department : Essence
    {
       
        public ObservableCollection<Department> Nodes { get; set; }

        public ObservableCollection<Employee> Employees { get; set; }

        public Department()
        {
            Nodes = new ObservableCollection<Department>();
            Employees = new ObservableCollection<Employee>();
        }
    }
}
