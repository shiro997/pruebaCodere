using AutoMapper;
using EmployeeAPI.Data;
using EmployeeAPI.DTO;
using EmployeeAPI.Model;

namespace EmployeeAPI.Implementation
{
    public class EmployeeImpl
    {
        private readonly EmployeeData _employeeData;

        public EmployeeImpl(EmployeeData data)
        {
            _employeeData = data;
        }

        public async Task<List<EmployeeDTO>>GetEmployeeDTOsAsync()
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();   
            var data = await _employeeData.GetAllEmployeesAsync();
            foreach (var emp in data)
            {
                var e = Mapper.Map<EmployeeDTO>(emp);
                employees.Add(e);
            }
            return employees;
        }

        public async Task<EmployeeDTO> GetEmployeeDTOByIdAsync(int codeEmployee)
        {
            var emp = await _employeeData.GetEmployeeByIdAsync(codeEmployee);
            var e = Mapper.Map<EmployeeDTO>(emp);
            return e;
        }

        public async Task<List<EmployeeDTO>> GetEmployeesByGroupDTOAsync(int codeGroup)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            var data = await _employeeData.GetEmployeesByGroup(codeGroup);
            foreach (var emp in data)
            {
                var e = Mapper.Map<EmployeeDTO>(emp);
                employees.Add(e);
            }
            return employees;
        }

        public async Task AddEmployeeDTOAsync(EmployeeDTO employeeDTO)
        {
            var emp = Mapper.Map<Employee>(employeeDTO);
            await _employeeData.AddEmployeeAsync(emp);
        }
    }
}
