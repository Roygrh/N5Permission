using AutoMapper;
using EmployeePermission.DTO;
using EmployeePermission.Models;
using EmployeePermission.Services.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePermission.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Employee_PermissionController : ControllerBase
    {
        //I'm sorry for being so late in submitting the challenge. It also doesn't comply with elasticsearch or kafka.


        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Employee_PermissionController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        [HttpPost("request_permission")]
        public ActionResult RequestPermission(RequestPermissionDto permission)
        {
            if (string.IsNullOrEmpty(permission.Name) || string.IsNullOrEmpty(permission.EmployeeName) || string.IsNullOrEmpty(permission.PermissionTypeName))
            {
                return StatusCode(500, "All fields must have value.");
            }

            var permissionDb = this._mapper.Map<Permission>(permission);

            this._unitOfWork.Employees.Add(permissionDb.Employee);
            this._unitOfWork.PermissionTypes.Add(permissionDb.PermissionType);
            this._unitOfWork.Permissions.Add(permissionDb);
            this._unitOfWork.Commit();

            return StatusCode(201, "The permission request was successful.");
        }

        [HttpPost("modify-permission")]
        public ActionResult ModifyPermission(PermissionModifyDto permission)
        {
            if (permission.IDEmployee == null || permission.IDType == null)
            {
                return StatusCode(500, "All fields must have value.");
            }

            var permissionDb = this._unitOfWork.Permissions.GetById(permission.ID);
            var employee = this._unitOfWork.Employees.GetById(permission.IDEmployee);
            var permissionType = this._unitOfWork.PermissionTypes.GetById(permission.IDType);

            if (permission == null)
            {
                return StatusCode(500, "The permission you want to modify does not exist.");
            }
            else if (employee == null)
            {
                return StatusCode(500, "The employee you indicated does not exist.");
            }
            else if (permissionType == null)
            {
                return StatusCode(500, "The type of permission you want to modify does not exist.");
            }
            else
            {
                permissionDb.Name = permission.Name;
                permissionDb.IDEmployee = permission.IDEmployee;
                permissionDb.IDType = permission.IDType;

                this._unitOfWork.Permissions.Update(permissionDb);

                this._unitOfWork.Commit();

                return StatusCode(200, "The permission was successfully updated.");
            }
            
        }

        [HttpGet("get-permissions")]
        public List<PermissionDto> GetPermissions()
        {
            var permissionsDb = this._unitOfWork.Permissions.Get().ToList();
            var permissionTypes = this._unitOfWork.PermissionTypes.Get().ToList();
            var employees = this._unitOfWork.Employees.Get().ToList();

            permissionsDb.ForEach(p => {
                p.Employee = employees.Find(e => e.ID == p.IDEmployee);
                p.PermissionType = permissionTypes.Find(pt => pt.ID == p.IDType);
            });

            var permissions = this._mapper.Map<List<PermissionDto>>(permissionsDb);

            return permissions;
        }
    }
}
