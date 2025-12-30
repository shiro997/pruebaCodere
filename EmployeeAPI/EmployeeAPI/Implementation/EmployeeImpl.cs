using AutoMapper;
using EmployeeAPI.Data;
using EmployeeAPI.DTO;
using EmployeeAPI.Model;

namespace EmployeeAPI.Implementation
{
    public class EmployeeImpl: IEmployeeImpl
    {
        private readonly IEmployeeData _employeeData;
        private readonly IGroupData _groupData;
        private readonly IMapper _mapper;

        public EmployeeImpl(AppDbContext context, IMapper mapper)
        {
            _employeeData = new EmployeeData(context);
            _groupData = new GroupData(context);
            _mapper = mapper;
        }

        public async Task<List<EmployeeDTO>>GetEmployeeDTOsAsync()
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();   
            var data = await _employeeData.GetAllEmployeesAsync();
            foreach (var emp in data)
            {
                var gData = await _groupData.GetGroupByIdAsync(emp.CodeGroup);
                emp.Group = gData;
                var e = _mapper.Map<EmployeeDTO>(emp);
                employees.Add(e);
            }
            return employees;
        }

        public async Task<EmployeeDTO> GetEmployeeDTOByIdAsync(int codeEmployee)
        {
            var emp = await _employeeData.GetEmployeeByIdAsync(codeEmployee);
            var e = _mapper.Map<EmployeeDTO>(emp);
            return e;
        }

        public async Task<List<EmployeeDTO>> GetEmployeesByGroupDTOAsync(int codeGroup)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            var data = await _employeeData.GetEmployeesByGroup(codeGroup);
            foreach (var emp in data)
            {
                var e = _mapper.Map<EmployeeDTO>(emp);
                employees.Add(e);
            }
            return employees;
        }

        public async Task<EmployeeDTO> AddEmployeeDTOAsync(EmployeeDTO employeeDTO)
        {
            try 
            {
                var emp = _mapper.Map<Employee>(employeeDTO);
                var status = await _employeeData.AddEmployeeAsync(emp);
                if (status == 0) 
                {
                    throw new ApplicationException("The provided employee can not be saved");
                }
                return employeeDTO;

            }
            catch (Exception ex) 
            {
                throw ex;
            }

        }

        public async Task<bool> UpdateEmployeeDTOAsync(int codeEmployee, EmployeeDTO employeeDTO)
        {
            try 
            {
                if (codeEmployee == 0) 
                {
                    throw new ArgumentNullException("CodeEmployee is null or zero");
                }
                var emp = await _employeeData.GetEmployeeByIdAsync(codeEmployee);
                if (emp == null) 
                {
                    throw new KeyNotFoundException("Employee not found");
                }
                var empN = _mapper.Map<Employee>(employeeDTO);
                await _employeeData.UpdateEmployeeAsync(empN);
                return !emp.Equals(empN);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteEmployeeDTOAsync(int id)
        {
            try 
            {
                if (id == 0) 
                {
                    throw new ArgumentNullException("CodeEmployee is null or zero");
                }
                
                return await _employeeData.DeleteEmployeeAsync(id)>0;
            } 
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
