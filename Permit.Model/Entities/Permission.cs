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
        public DateTime CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? UpdatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CreatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string UpdatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        [ForeignKey("PermissionType")]
        public int PermissionType { get; set; }
        public DateTime CreatePermission { get; set; }
        public virtual PermissionType PermissionId {get; set;}
        
    }
}
