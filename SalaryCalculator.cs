using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_leson11
{
    public class SalaryCalculator
    {
        public decimal Calculate(IEmployee employee)
        {
            return employee.CalculateSalary();
        }
    }
}
