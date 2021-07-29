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

        MainWindowViewModel viewModel;

        Essence selected;

        public MainWindow()
        {
            InitializeComponent();
            selected = new Essence();

            viewModel = new MainWindowViewModel();

            DataContext = viewModel;


            nodes = new ObservableCollection<Department>
            {
                new Department
                {
                    Name ="Главный департамент",
                    Id = 1,
                    
                    Nodes = new ObservableCollection<Department>
                    {
                        new Department {Name="Отдел аналитике", Id = 2},
                        new Department {Name="Отдел ТП", Id = 3 },
                        new Department
                        {
                            Name ="Отедел разработки", Id = 4,
                            Nodes = new ObservableCollection<Department>
                            {
                                new Department {Name="Группа фронтенд", Id = 5 },
                                new Department {Name="Группа бэкенд", Id = 6 },
                            }
                    }
                }
            }
            };

            organization = new Organization
            {
                Name = "ООО Новые разработки",
                Nodes = nodes,
                Type = new OrganizationType { Name = "ООО", FullName = "Общество с ограниченной ответственностью"}
            };

            var oneOrg = new ObservableCollection<Organization>
            {
                organization
            };

            var service = new DepartmentService(organization);

            var dep1 = service.GetDepartmentById(1);

            var emp1 = new LeaderEmployee
            {
                FirstName = "Иван",
                LastName = "Драго",
                Type = EmployeeType.Leader,
                Department = dep1
            };

            dep1.Employees.Add(emp1);

            treeView1.ItemsSource = oneOrg;
        }

        private void treeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            selected = (Essence)e.NewValue;

            viewModel.Name = selected.Name;

            //MessageBox.Show(selected.Name);
        }
    }
}
