using System.Diagnostics.CodeAnalysis;

namespace EmployeeAPI.Model
{
    public class Employee
    {
        public int CodeEmployee { get; set; }
        public string NameEmployee { get; set; }
        public string JobTitle { get; set; }    
        public decimal Salary { get; set; } 
        public int CodeGroup { get; set; }
        public Group Group { get; set; }
        [AllowNull]
        public int CodeLeader { get; set; }
        public Employee Leader { get; set; }    
    }
}
