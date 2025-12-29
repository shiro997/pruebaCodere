using AutoMapper;
using EmployeeAPI.Data;
using EmployeeAPI.DTO;

namespace EmployeeAPI.Implementation
{
    public class GroupImpl
    {
        private readonly GroupData _groupData;

        public GroupImpl(GroupData groupData)
        {
            _groupData = groupData;
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
