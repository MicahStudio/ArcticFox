using ArcticFox.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArcticFox.Core.Temp
{
    public class Temp : AuditedEntity
    {
        public string Name { set; get; }
    }
}
