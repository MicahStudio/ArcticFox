using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArcticFox.EntityFrameworkCore
{
    public class Entity : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        [ConcurrencyCheck]
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
    public class Entity<TPKey> : IEntity<TPKey> where TPKey : struct
    {
        [Key]
        public TPKey Id { get; set; }
        [ConcurrencyCheck]
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
