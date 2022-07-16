using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePermission.DTO
{
    public class RequestPermissionDto
    {
        public string Name { get; set; }
        public string EmployeeName { get; set; }
        public string PermissionTypeName { get; set; }
    }
}
