using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_leson11
{
    public class InternEmployee : Employee, IEmployee
    {
        

        public InternEmployee()
        {
            salary = 200;
        }

        public decimal CalculateSalary()
        {
            return salary;
        }
    }
}
