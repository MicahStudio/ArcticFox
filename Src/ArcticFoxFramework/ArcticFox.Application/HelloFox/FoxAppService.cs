using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ArcticFox.Controllers.Dtos;
using ArcticFox.Core.Temp;
using ArcticFox.Repositories;

namespace ArcticFox.Application.HelloFox
{
    public class FoxAppService : BaseAppService, IFoxAppService
    {
        private readonly IRepository<Temp, int> repository;
        public FoxAppService(IRepository<Temp, int> repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public string Bye()
        {
            var xx = repository.Insert(new Temp { Name = "xxxxx" });
            return "Bye";
        }
        [HttpPost]
        public string Exception()
        {
            throw new Exception("啊！");
        }
        [HttpPost]
        public string Hello([FromBody] IdInput<string> input)
        {
            return input.Id;
        }
    }
}
