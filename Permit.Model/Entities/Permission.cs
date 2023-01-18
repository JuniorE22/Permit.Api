using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Permit.Model.Entities
{
    public class Permission : IBaseEntity, IAuditEntity, ISoftDeleteEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        #region Properties
        public string Name { get; set; }
        public string LastName { get; set; }
        public int PermitType { get; set; }
        public DateTime PermitDate { get; set; }
        #endregion
        #region  Audit Entity
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        #endregion

        [ForeignKey("PermissionType")]
        public int PermissionType { get; set; }
        public DateTime CreatePermission { get; set; }
        public virtual PermissionType PermissionId {get; set;}
    }
}
