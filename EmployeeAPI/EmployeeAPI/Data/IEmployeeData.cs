using EmployeeAPI.Model;

namespace EmployeeAPI.Data
{
    public interface IEmployeeData
    {
        public Task<List<Employee>> GetAllEmployeesAsync();
        public Task<Employee> GetEmployeeByIdAsync(int codeEmployee);
        public Task<List<Employee>> GetEmployeesByGroup(int codeGroup);
        public Task<int> AddEmployeeAsync(Employee employee);
        public Task<int> UpdateEmployeeAsync(Employee employee);
        public Task<int> DeleteEmployeeAsync(int codeEmployee);
    }
}
