using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_leson11
{
    public class Employee
    {
        protected decimal salary;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Department Department { get; set; }

        public Organization Organization { get; set; }

        protected EmployeeType Type { get; set; }

        //public Employee(Organization organization, Department department)
        //{
        //    Organization = organization;
        //    Department = department;
        //}
    }
}
