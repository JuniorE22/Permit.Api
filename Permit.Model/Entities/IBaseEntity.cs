using System;
using System.Collections.Generic;
using System.Text;

namespace Permit.Model.Entities
{
    public interface IAuditEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
    public interface IBaseEntity
    {
        public int Id { get; set; }
    }
    public interface ISoftDeleteEntity
    {
        public bool IsDeleted { get; set; }
    }
}
