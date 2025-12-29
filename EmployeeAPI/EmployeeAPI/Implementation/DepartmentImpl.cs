using AutoMapper;
using EmployeeAPI.Data;
using EmployeeAPI.DTO;

namespace EmployeeAPI.Implementation
{
    public class DepartmentImpl : IDepartmentImpl
    {
        private readonly IDepartmentData _departmentData;
        private readonly IMapper _mapper;


        public DepartmentImpl(AppDbContext context, IMapper mapper)
        {
            _departmentData = new DepartmentData(context);
            _mapper = mapper;
        }

        public async Task<List<DepartmentDTO>> GetAllDepartmentsAsync()
        {
            List<DepartmentDTO> departments = new List<DepartmentDTO>();
            var data = await _departmentData.GetAllDepartmentsAsync();
            foreach (var  d in data)
            {
                var dep = _mapper.Map<DepartmentDTO>(d);
                departments.Add(dep);
            }
            return departments;
        }
        public async Task<DepartmentDTO> GetDepartmentByIdAsync(int codeDepartment)
        {
            var data = await _departmentData.GetDepartmentByIdAsync(codeDepartment);
            var department = _mapper.Map<DepartmentDTO>(data);
            return department;
        }   
    }
}
