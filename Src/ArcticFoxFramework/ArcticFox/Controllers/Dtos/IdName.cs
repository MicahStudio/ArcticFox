using System;
using System.Collections.Generic;
using System.Text;

namespace ArcticFox.Controllers.Dtos
{
    public class IdName
    {
        public int Id { set; get; }
        public string Name { set; get; }
    }
    public class IdName<Key>
    {
        public Key Id { set; get; }
        public string Name { set; get; }
    }
}

