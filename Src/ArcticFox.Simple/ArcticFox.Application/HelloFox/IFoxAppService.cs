using ArcticFox.Controllers.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArcticFox.Application.HelloFox
{
    public interface IFoxAppService
    {
        string Hello([FromBody] IdInput<string> input);
        string Exception();
        string Bye();
    }
}
