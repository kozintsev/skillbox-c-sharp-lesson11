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
    }
}
