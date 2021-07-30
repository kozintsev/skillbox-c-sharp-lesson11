using System.Collections.ObjectModel;

namespace test_leson11
{
    public class EmployeeService
    {
        public static decimal GetMoney(Department department)
        {
            decimal d = 0;
            foreach(var item in department.Employees)
            {
                if (item.GetEmployeeType() == EmployeeType.Leader)
                {
                    continue;
                }
                d += item.CalculateSalary();
            }
            return d;
        }

        public static decimal GetTotalMoney(ObservableCollection<IEmployee> employees)
        {
            decimal total = 0;
            foreach(var item in employees)
            {
                total += item.CalculateSalary();
            }

            return total;
        }
    }
}
