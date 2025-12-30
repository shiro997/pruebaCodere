using AutoMapper;
using EmployeeAPI.Data;
using EmployeeAPI.DTO;
using EmployeeAPI.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route ("api/v1/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly AppDbContext _context;
        private readonly IEmployeeImpl _employeeImpl;

        public EmployeeController(AppDbContext con,IMapper mapper)
        {
            _context = con;
            _employeeImpl = new EmployeeImpl(_context, mapper);
        }

        // GET: EmployeeController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try 
            {
                var employees = await _employeeImpl.GetEmployeeDTOsAsync();
                return Ok(employees);
            } 
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: EmployeeController/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try 
            {
                var employee =  await _employeeImpl.GetEmployeeDTOByIdAsync(id);
                return Ok(employee);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Group/{groupId}")]
        public async Task<IActionResult> GetEmployeesByGroup(int groupId)
        {
            try 
            {
                var employees =  await _employeeImpl.GetEmployeesByGroupDTOAsync(groupId);
                return Ok(employees);
            } 
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        

        // POST: EmployeeController/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeDTO employee)
        {
            try
            {
                var createdEmployee = await _employeeImpl.AddEmployeeDTOAsync(employee);

                return Ok(createdEmployee);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: EmployeeController/Edit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] EmployeeDTO employee)
        {
            try 
            {
                var updatedEmployee = await _employeeImpl.UpdateEmployeeDTOAsync(id, employee);
                return Ok(updatedEmployee); 
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: EmployeeController/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _employeeImpl.DeleteEmployeeDTOAsync(id);

                if(!result) throw new Exception("The employee could not be deleted"); 

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
