
using System.Diagnostics.CodeAnalysis;

namespace EmployeeAPI.DTO
{
    public class EmployeeDTO
    {
        public int CodeEmployee { get; set; }
        public string NameEmployee { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
        public int CodeGroup { get; set; }
        [AllowNull]
        public string NameGroup { get; set; }
        [AllowNull]
        public string NameLeader { get; set; }
        public int CodeLeader { get; set; }    
    }
}
