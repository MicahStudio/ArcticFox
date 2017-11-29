using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArcticFox.EntityFrameworkCore
{
    public interface IEntity : IEntity<int>
    {
    }
    public interface IEntity<TPKey>
    {
    }
    public interface IAuditedEntity : IEntity<int>
    {

    }
    public interface IAuditedEntity<TPkey> : IEntity<TPkey>
    {

    }
}
