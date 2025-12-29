using AutoMapper;
using EmployeeAPI.Data;
using EmployeeAPI.DTO;

namespace EmployeeAPI.Implementation
{
    public class GroupImpl : IGroupImpl
    {
        private readonly IGroupData _groupData;

        public GroupImpl(AppDbContext context)
        {
            _groupData = new GroupData(context);
        }

        public async Task<List<GroupDTO>> GetAllGroupsAsync()
        {
            List<GroupDTO> groups = new List<GroupDTO>();
            var data = await _groupData.GetAllGroupsAsync();
            foreach (var g in data)
            {
                var group = Mapper.Map<GroupDTO>(g);
                groups.Add(group);
            }
            return groups;
        }
        public async Task<GroupDTO> GetGroupByIdAsync(int codeGroup)
        {
            var data = await _groupData.GetGroupByIdAsync(codeGroup);
            var group = Mapper.Map<GroupDTO>(data);
            return group;
        }   

    }
}
