using AutoMapper;
using EmployeeAPI.Data;
using EmployeeAPI.DTO;

namespace EmployeeAPI.Implementation
{
    public class GroupImpl : IGroupImpl
    {
        private readonly IGroupData _groupData;
        private readonly IMapper _mapper;

        public GroupImpl(AppDbContext context, IMapper mapper)
        {
            _groupData = new GroupData(context);
            _mapper = mapper;
        }

        public async Task<List<GroupDTO>> GetAllGroupsAsync()
        {
            List<GroupDTO> groups = new List<GroupDTO>();
            var data = await _groupData.GetAllGroupsAsync();
            foreach (var g in data)
            {
                var group = _mapper.Map<GroupDTO>(g);
                groups.Add(group);
            }
            return groups;
        }
        public async Task<GroupDTO> GetGroupByIdAsync(int codeGroup)
        {
            var data = await _groupData.GetGroupByIdAsync(codeGroup);
            var group = _mapper.Map<GroupDTO>(data);
            return group;
        }   

    }
}
