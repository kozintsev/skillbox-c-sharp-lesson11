namespace test_leson11
{
    public class LeaderEmployee : Employee, IEmployee
    {
        public LeaderEmployee()
        {
            Type = EmployeeType.Leader;
        }
        public decimal CalculateSalary()
        {
            var m = EmployeeService.GetMoney(Department);
            var sal = (double)m * 0.15;
            if (sal < 1500){
                return 1500;
            };

            return decimal.Parse(sal.ToString());
        }

        public EmployeeType GetEmployeeType()
        {
            return Type;
        }
    }
}
