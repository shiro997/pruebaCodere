using EmployeeAPI.Model;

namespace EmployeeAPI.Data
{
    public interface IGroupData
    {
        public Task<List<Group>> GetAllGroupsAsync();
        public Task<Group> GetGroupByIdAsync(int codeGroup);
    }
}
