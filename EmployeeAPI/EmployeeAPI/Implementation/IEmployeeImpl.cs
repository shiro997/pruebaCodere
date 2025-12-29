using EmployeeAPI.DTO;

namespace EmployeeAPI.Implementation
{
    public interface IEmployeeImpl
    {
        public Task<List<EmployeeDTO>> GetEmployeeDTOsAsync();
        public Task<EmployeeDTO> GetEmployeeDTOByIdAsync(int codeEmployee); 
        public Task<List<EmployeeDTO>> GetEmployeesByGroupDTOAsync(int codeGroup);
        public Task<EmployeeDTO> AddEmployeeDTOAsync(EmployeeDTO employeeDTO);
        public Task<bool> UpdateEmployeeDTOAsync(int codeEmployee, EmployeeDTO employeeDTO);
        public Task<bool> DeleteEmployeeDTOAsync(int id);

    }
}
