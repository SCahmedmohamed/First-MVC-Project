using AutoMapper;
using Data_Access_Layer.Models;
using Presntation__Layer.DTOs.EmployeeDTOs;

namespace Presntation__Layer.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, CreateEmployeeDTO>().ReverseMap(); 
            CreateMap<Employee, DetailsEmployeeDTO>().ReverseMap();
            CreateMap<Employee, DeleteEmployeeDTO>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDTO>().ReverseMap();

        }
    }
}
