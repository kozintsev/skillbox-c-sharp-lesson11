using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace test_leson11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Department> nodes;
        Organization organization;

        public MainWindow()
        {
            InitializeComponent();

            

            nodes = new ObservableCollection<Department>
            {
                new Department
            {
                Name ="Европа",
                Nodes = new ObservableCollection<Department>
                {
                    new Department {Name="Германия" },
                    new Department {Name="Франция" },
                    new Department
                    {
                        Name ="Великобритания",
                        Nodes = new ObservableCollection<Department>
                        {
                            new Department {Name="Англия" },
                            new Department {Name="Шотландия" },
                            new Department {Name="Уэльс" },
                            new Department {Name="Сев. Ирландия" },
                        }
                    }
                }
            },
                new Department
            {
                Name ="Азия",
                Nodes = new ObservableCollection<Department>
                {
                    new Department {Name="Китай" },
                    new Department {Name="Япония" },
                    new Department { Name ="Индия" }
                }
            },
                new Department { Name="Африка" },
                new Department { Name="Америка" },
                new Department { Name="Австралия" }
            };

            organization = new Organization
            {
                Name = "ООО Мираж",
                Nodes = nodes,
                Type = new OrganizationType { Name = "ООО", FullName = "Общество с ограниченной ответственностью"}
            };

            var oneOrg = new ObservableCollection<Organization>
            {
                organization
            };

            treeView1.ItemsSource = oneOrg;
        }
    }
}
