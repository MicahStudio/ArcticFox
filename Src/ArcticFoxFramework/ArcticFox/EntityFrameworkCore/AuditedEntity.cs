using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ArcticFox.EntityFrameworkCore
{
    public abstract class AuditedEntity<TPKey> : Entity<TPKey> where TPKey : struct
    {
        public bool IsDeleted { set; get; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DeletionTime { set; get; }
    }
}
