using EmployeeAPI.Model;

namespace EmployeeAPI.Data
{
    public interface IDepartmentData
    {
        public Task<List<Department>> GetAllDepartmentsAsync();
        public Task<Department> GetDepartmentByIdAsync(int codeDepartment);
    }
}
