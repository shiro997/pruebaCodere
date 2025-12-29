using EmployeeAPI.DTO;

namespace EmployeeAPI.Implementation
{
    public interface IDepartmentImpl
    {
        public Task<List<DepartmentDTO>> GetAllDepartmentsAsync();
        public Task<DepartmentDTO> GetDepartmentByIdAsync(int codeDepartment);
    }
}
