using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_leson11
{
    class WorkerEmployee : Employee, IEmployee
    {
        private decimal ratePerHour;
        private decimal hourPerMonth;

        public WorkerEmployee()
        {
            ratePerHour = 10;
            hourPerMonth = 160;
        }

        public decimal CalculateSalary()
        {
            return ratePerHour * hourPerMonth;
        }

    }
}
