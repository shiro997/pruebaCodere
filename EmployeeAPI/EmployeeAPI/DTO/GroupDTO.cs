using EmployeeAPI.Model;

namespace EmployeeAPI.DTO
{
    public class GroupDTO
    {
        public int CodeGroup { get; set; }
        public string NameGroup { get; set; }
        public int CodeDepartment { get; set; }
        public DepartmentDTO Department { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
    }
}
