using AutoMapper;
using EmployeeAPI.Data;
using EmployeeAPI.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]  
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IDepartmentImpl _department;

        public DepartmentController(AppDbContext con,IMapper mapper)
        {
            _context = con;
            _department = new DepartmentImpl(_context, mapper);
        }

        // GET: HomeController
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            try 
            {
                var departments =  await _department.GetAllDepartmentsAsync();
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: HomeController/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            try 
            {
                var department =  await _department.GetDepartmentByIdAsync(id);
                return Ok(department);
            } 
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);  
            }
        }

        
    }
}
