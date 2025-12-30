using EmployeeAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class EmployeeData : IEmployeeData
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

        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            try
            {
                await _context.Employees.AddAsync(employee);
                return await _context.SaveChangesAsync();
            }
            catch (InvalidDataException exs)
            {
                throw new InvalidDataException("Error adding employee, " + exs.Message, exs);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding employee, " + ex.Message, ex);
            }
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                var updatedEmployee =await _context.Employees.FindAsync(employee.CodeEmployee);
                updatedEmployee.NameEmployee = employee.NameEmployee;
                updatedEmployee.JobTitle = employee.JobTitle;
                updatedEmployee.Salary = employee.Salary;
                updatedEmployee.CodeGroup = employee.CodeGroup;
                updatedEmployee.CodeLeader = employee.CodeLeader;

                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating employee, " + ex.Message, ex);
            }
        }

        public async Task<int> DeleteEmployeeAsync(int codeEmployee)
        {
            try
            {
                var employee = await GetEmployeeByIdAsync(codeEmployee);
                if (employee == null)
                {
                    throw new KeyNotFoundException("Employee not found");
                }
                _context.Employees.Remove(employee);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting employee, " + ex.Message, ex);
            }
        }   

    }
}
