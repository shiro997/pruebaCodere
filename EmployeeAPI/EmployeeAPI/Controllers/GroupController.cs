using AutoMapper;
using EmployeeAPI.Data;
using EmployeeAPI.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IGroupImpl _group;
        public GroupController(AppDbContext con, IMapper mapper)
        {
            _context = con;
            _group = new GroupImpl(_context,mapper);
        }

        // GET: GroupController
        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            try 
            {
                var groups = await _group.GetAllGroupsAsync();
                return Ok(groups);
            } 
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: GroupController/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupById(int id)
        {
            try 
            {
                var group =  await _group.GetGroupByIdAsync(id);
                return Ok(group);
            } 
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
