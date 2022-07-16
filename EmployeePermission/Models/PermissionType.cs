using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePermission.Models
{
    public class PermissionType
    {
        public PermissionType()
        {
        }

        public PermissionType(string name)
        {
            this.Name = name;
        }

        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("ID", TypeName = "numeric(11,0)")]
        public decimal ID { get; set; }
        public string Name { get; set; }
    }
}
