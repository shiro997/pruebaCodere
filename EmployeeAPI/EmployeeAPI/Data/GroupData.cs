using EmployeeAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class GroupData
    {
        private readonly AppDbContext _context;
        public GroupData(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Group>> GetAllGroupsAsync()
        {
            try
            {
                return await _context.Groups.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving groups, " + ex.Message, ex);
            }
        }
        public async Task<Group> GetGroupByIdAsync(int codeGroup)
        {
            try
            {
                var group = await _context.Groups
                                .FirstOrDefaultAsync(g => g.CodeGroup == codeGroup);
                return group;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving groups, " + ex.Message, ex);
            }
        }
    }
}
