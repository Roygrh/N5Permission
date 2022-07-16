using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePermission.DTO
{
    public class PermissionDto
    {
        public decimal ID { get; set; }
        public string Name { get; set; }
        public decimal IDEmployee { get; set; }
        public string EmployeeName { get; set; }
        public decimal IDPermissionType { get; set; }
        public string TypeName { get; set; }
    }
}
