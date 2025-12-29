using EmployeeAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class DepartmentData
    {
        private readonly AppDbContext _context;

        public DepartmentData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            try
            {
                return await _context.Departments.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving departments, "+ex.Message, ex);
            } 

        }
        public async Task<Department> GetDepartmentByIdAsync(int codeDepartment)
        {
            try
            {
                var department = await _context.Departments
                                .FirstOrDefaultAsync(d => d.CodeDepartment == codeDepartment);
                return department;
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving departments, "+ ex.Message, ex);
            }
            
        }

    }
}
