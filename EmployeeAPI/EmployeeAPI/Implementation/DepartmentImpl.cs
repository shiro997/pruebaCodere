using AutoMapper;
using EmployeeAPI.Data;
using EmployeeAPI.DTO;

namespace EmployeeAPI.Implementation
{
    public class DepartmentImpl
    {
        private readonly DepartmentData _departmentData;
        public DepartmentImpl(DepartmentData departmentData)
        {
            _departmentData = departmentData;
        }

        public async Task<List<DepartmentDTO>> GetAllDepartmentsAsync()
        {
            List<DepartmentDTO> departments = new List<DepartmentDTO>();
            var data = await _departmentData.GetAllDepartmentsAsync();
            foreach (var  d in data)
            {
                var dep = Mapper.Map<DepartmentDTO>(d);
                departments.Add(dep);
            }
            return departments;
        }
        public async Task<DepartmentDTO> GetDepartmentByIdAsync(int codeDepartment)
        {
            var data = await _departmentData.GetDepartmentByIdAsync(codeDepartment);
            var department = Mapper.Map<DepartmentDTO>(data);
            return department;
        }   
    }
}
