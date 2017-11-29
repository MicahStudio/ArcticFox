using ArcticFox.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArcticFox.Attributes
{
    public class AuditingAttribute : ActionFilterAttribute
    {
        public bool IsAuditing { set; get; }
        public AuditingAttribute(bool IsAuditing = true)
        {
            this.IsAuditing = IsAuditing;
        }
    }
}
