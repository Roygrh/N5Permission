using EmployeePermission.Data;
using EmployeePermission.Models;
using EmployeePermission.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePermission.Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext _context;
        private GenericRepository<Employee> EmployeeRepository;
        private GenericRepository<Permission> PermissionRepository;
        private GenericRepository<PermissionType> PermissionTypeRepository;
        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        IRepository<Employee> IUnitOfWork.Employees
        {
            get
            {

                if (this.EmployeeRepository == null)
                {
                    this.EmployeeRepository = new GenericRepository<Employee>(_context);
                }
                return EmployeeRepository;
            }
        }

        IRepository<Permission> IUnitOfWork.Permissions
        {
            get
            {

                if (this.PermissionRepository == null)
                {
                    this.PermissionRepository = new GenericRepository<Permission>(_context);
                }
                return PermissionRepository;
            }
        }

        IRepository<PermissionType> IUnitOfWork.PermissionTypes
        {
            get
            {

                if (this.PermissionTypeRepository == null)
                {
                    this.PermissionTypeRepository = new GenericRepository<PermissionType>(_context);
                }
                return PermissionTypeRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void RollBack()
        {
            //TODO
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
