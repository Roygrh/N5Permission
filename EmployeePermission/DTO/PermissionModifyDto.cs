using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePermission.DTO
{
    public class PermissionModifyDto
    {
        public decimal ID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> IDEmployee { get; set; }
        public Nullable<decimal> IDType { get; set; }
    }
}
