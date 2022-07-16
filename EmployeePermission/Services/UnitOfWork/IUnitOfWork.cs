using EmployeePermission.Models;
using EmployeePermission.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePermission.Services.UnitOfWork
{
    public interface IUnitOfWork
    {

        IRepository<Employee> Employees { get; }
        IRepository<Permission> Permissions { get; }
        IRepository<PermissionType> PermissionTypes { get; }

        void Commit();
        void RollBack();
    }
}
