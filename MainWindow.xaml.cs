using System.Collections.ObjectModel;
using System.Linq;
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
                Department = dep1
            };

            var dep2 = service.GetDepartmentById(4);

            var emp2 = new LeaderEmployee
            {
                FirstName = "Петр",
                LastName = "Сидоров",
                Department = dep2
            };

            var emp3 = new InternEmployee
            {
                FirstName = "Олег",
                LastName = "Иванов",
                Department = dep2
            };

            var emp4 = new WorkerEmployee
            {
                FirstName = "Тима",
                LastName = "Иванов",
                Department = dep2
            };

            var dep3 = service.GetDepartmentById(5);

            var emp5 = new InternEmployee
            {
                FirstName = "Семён",
                LastName = "Владимиров",
                Department = dep3
            };


            dep1.Employees.Add(emp1);
            dep2.Employees.Add(emp2);
            dep2.Employees.Add(emp3);
            dep2.Employees.Add(emp4);
            dep3.Employees.Add(emp5);

            treeView1.ItemsSource = oneOrg;
        }

        private void treeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            selected = (Essence)e.NewValue;
            var item = selected as Department;

            if (item != null)
            {
                var emp = item.Employees.FirstOrDefault();

                if (emp != null)
                {
                    Employee emp1 = (Employee)emp;
                    viewModel.Name = emp1.FirstName + ' ' + emp1.LastName;
                    viewModel.Salary = emp.CalculateSalary();

                }

            }

        }
    }
}
