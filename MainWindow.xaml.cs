using System.Collections.ObjectModel;
using System.Windows;

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

            var dep2 = service.GetDepartmentById(4);

            var emp2 = new LeaderEmployee
            {
                FirstName = "Петр",
                LastName = "Сидоров",
                Type = EmployeeType.Leader,
                Department = dep2
            };

            var emp3 = new InternEmployee
            {
                FirstName = "Олег",
                LastName = "Иванов",
                Type = EmployeeType.Intern,
                Department = dep2
            };

            var emp4 = new WorkerEmployee
            {
                FirstName = "Тима",
                LastName = "Иванов",
                Type = EmployeeType.Worker,
                Department = dep2
            };


            dep1.Employees.Add(emp1);
            dep2.Employees.Add(emp2);
            dep2.Employees.Add(emp3);
            dep2.Employees.Add(emp4);

            treeView1.ItemsSource = oneOrg;
        }

        private void treeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            selected = (Essence)e.NewValue;

            viewModel.Name = selected.Name;

        }
    }
}
