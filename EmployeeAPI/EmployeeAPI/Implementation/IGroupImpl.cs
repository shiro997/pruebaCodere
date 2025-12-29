using EmployeeAPI.DTO;

namespace EmployeeAPI.Implementation
{
    public interface IGroupImpl
    {
        public Task<List<GroupDTO>> GetAllGroupsAsync();
        public Task<GroupDTO> GetGroupByIdAsync(int codeGroup);

    }
}
