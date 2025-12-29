namespace EmployeeAPI.Model
{
    public class Group
    {
        public int CodeGroup { get; set; }
        public string NameGroup { get; set; }
        public int CodeDepartment { get; set; } 
        public Department Department { get; set; } 
        public ICollection<Employee> Employees { get; set; }
    }
}
