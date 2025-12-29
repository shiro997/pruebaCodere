using EmployeeAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class EmployeeData
    {
        private readonly AppDbContext _context;
        public EmployeeData(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            try
            {
                return await _context.Employees.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving employees, " + ex.Message, ex);
            }
        }   

        public async Task<Employee> GetEmployeeByIdAsync(int codeEmployee)
        {
            try
            {
                var employee = await _context.Employees
                                .FirstOrDefaultAsync(e => e.CodeEmployee == codeEmployee);
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving employees, " + ex.Message, ex);
            }
        }

        public async Task<List<Employee>> GetEmployeesByGroup(int codeGroup) 
        {
            try 
            {
                return await _context.Employees
                             .Where(e => e.CodeGroup == codeGroup)
                             .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving employees by group, " + ex.Message, ex);
            }   
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            try
            {
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding employee, " + ex.Message, ex);
            }
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating employee, " + ex.Message, ex);
            }
        }

        public async Task DeleteEmployeeAsync(int codeEmployee)
        {
            try
            {
                var employee = await GetEmployeeByIdAsync(codeEmployee);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting employee, " + ex.Message, ex);
            }
        }   

    }
}
