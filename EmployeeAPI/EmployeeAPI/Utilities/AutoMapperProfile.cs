using AutoMapper;

namespace EmployeeAPI.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Model.Employee, DTO.EmployeeDTO>()
                .ForMember(e => e.NameLeader, opt =>
                    opt.MapFrom(src => src.Leader != null ? src.Leader.NameEmployee : null)
                )
                .ForMember(e => e.NameGroup, opt => 
                    opt.MapFrom(src => src.Group != null ? src.Group.NameGroup : null)
                );
            CreateMap<DTO.EmployeeDTO, Model.Employee>()
                .ForMember(e => e.CodeLeader, opt =>
                    opt.MapFrom(src => src.CodeLeader)
                );

            CreateMap<Model.Group, DTO.GroupDTO>().ReverseMap();

            CreateMap<Model.Department, DTO.DepartmentDTO>().ReverseMap();


        }
    }
}
