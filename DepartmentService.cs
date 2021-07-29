using System.Collections.ObjectModel;

namespace test_leson11
{
    public class DepartmentService
    {
        private Organization _organization;
        public DepartmentService(Organization organization)
        {
            _organization = organization;
        }

        private static Department GetDepartmentByNodes(int id, ObservableCollection<Department> nodes)
        {
            foreach(var item in nodes)
            {
                if (item.Id == id)
                {
                    return item;
                }
                if (item.Nodes.Count > 0)
                {
                    return GetDepartmentByNodes(id, item.Nodes);
                }
            }

            return null;
        }

        public Department GetDepartmentById(int id)
        {

            foreach(var item in _organization.Nodes) 
            {
                if (item.Id == id)
                {
                    return item;
                }
                if (item.Nodes.Count > 0)
                {
                    return GetDepartmentByNodes(id, item.Nodes);
                }
            }

            return null;
        }
    }
}
