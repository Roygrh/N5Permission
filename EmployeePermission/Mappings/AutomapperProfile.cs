using AutoMapper;
using EmployeePermission.DTO;
using EmployeePermission.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePermission.Mappings
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<EmployeeDto, Employee>();
            CreateMap<PermissionDto, Permission>();
            CreateMap<PermissionTypeDto, PermissionType>();
            CreateMap<RequestPermissionDto, Permission>()
                .ForMember(entity => entity.Employee, dto => dto.MapFrom(e => new Employee(e.EmployeeName)))
                .ForMember(entity => entity.PermissionType, dto => dto.MapFrom(e => new PermissionType(e.PermissionTypeName)));
            CreateMap<RequestPermissionDto, Employee>()
                .ForMember(entity => entity.Name, dto => dto.MapFrom(e => e.EmployeeName));
            CreateMap<RequestPermissionDto, PermissionType>()
                .ForMember(entity => entity.Name, dto => dto.MapFrom(e => e.PermissionTypeName));
            CreateMap<PermissionModifyDto, Permission>();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<Permission, PermissionDto>()
                .ForMember(dto => dto.IDEmployee, entity => entity.MapFrom(e => e.Employee.ID))
                .ForMember(dto => dto.EmployeeName, entity => entity.MapFrom(e => e.Employee.Name))
                .ForMember(dto => dto.IDPermissionType, entity => entity.MapFrom(e => e.PermissionType.ID))
                .ForMember(dto => dto.TypeName, entity => entity.MapFrom(e => e.PermissionType.Name));
            CreateMap<PermissionType, PermissionTypeDto>();
        }
    }
}
