using AutoMapper;

namespace EmployeeAPI.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Model.Employee, DTO.EmployeeDTO>().ReverseMap();

            CreateMap<Model.Group, DTO.GroupDTO>().ReverseMap();

            CreateMap<Model.Department, DTO.DepartmentDTO>().ReverseMap();


        }
    }
}
