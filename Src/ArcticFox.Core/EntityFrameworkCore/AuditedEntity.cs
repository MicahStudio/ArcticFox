using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ArcticFox.EntityFrameworkCore
{
    public abstract class AuditedEntity : Entity<int>, IAuditedEntity<int>
    {
        public bool IsDeleted { set; get; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DeletionTime { set; get; }
    }
    public abstract class AuditedEntity<TPKey> : Entity<TPKey>, IAuditedEntity<TPKey> where TPKey : struct
    {
        public bool IsDeleted { set; get; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DeletionTime { set; get; }
    }
}
