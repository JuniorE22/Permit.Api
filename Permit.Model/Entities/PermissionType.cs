using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Permit.Model.Entities
{
    public class PermissionType : IBaseEntity, ISoftDeleteEntity, IAuditEntity
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        #region Properties
        public string Description { get; set; }
        #endregion
        #region Audit Entity
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        #endregion
    }
}
