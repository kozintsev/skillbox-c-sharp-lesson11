using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_leson11
{
    public class Organization : Essence
    {
        public ObservableCollection<Department> Nodes { get; set; }

        public OrganizationType Type { get; set; }
    }
}
