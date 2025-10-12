using AutoMapper;
using Data_Access_Layer.Models;
using Presntation__Layer.DTOs.DepartmentDTOs;

namespace Presntation__Layer.Mapping
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, CreateDepartmentDTO>().ReverseMap();
            CreateMap<Department, DetailsDepartmentDTO>().ReverseMap();
            CreateMap<Department, DeleteDepartmentDTO>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDTO>().ReverseMap();
        }
    }
}
