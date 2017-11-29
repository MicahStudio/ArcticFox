using System;
using System.Collections.Generic;
using System.Text;

namespace ArcticFox.Controllers.Dtos
{
    public class IdInput
    {
        public int Id { set; get; }
    }
    public class IdInput<Key>
    {
        public Key Id { set; get; }
    }
}
