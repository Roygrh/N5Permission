using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePermission.Models
{
    public class Permission
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("ID", TypeName ="numeric(11,0)")]
        public decimal ID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> IDEmployee { get; set; }
        public Nullable<decimal> IDType { get; set; }
        [ForeignKey("IDEmployee")]
        public virtual Employee Employee { get; set; }
        [ForeignKey("IDType")]
        public virtual PermissionType PermissionType { get; set; }
    }
}
