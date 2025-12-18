using AutoMapper;
using EmployeManagementApi1.DTOs;
using EmployeManagementApi1.Models;

namespace EmployeManagementApi1.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<Employee, CreateEmployeeDto>();   
            CreateMap<Employee, UpdateEmployeeDto>();   
        }
    }
}
