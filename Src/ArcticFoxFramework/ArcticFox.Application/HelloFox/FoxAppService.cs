using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ArcticFox.Controllers.Dtos;
using ArcticFox.Core.Temp;
using ArcticFox.Repositories;
using System.Linq;
using ArcticFox.Attributes;

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
            repository.Insert(new Temp { Name = "xxxxx" });
            repository.Insert(new Temp { Name = "xxxxx" });
            repository.Insert(new Temp { Name = "xxxxx" });
            repository.Insert(new Temp { Name = "xxxxx" });
            return "Bye";
        }
        [HttpPost]
        public string Exception()
        {
            throw new Exception("啊！");
        }
        [HttpPost]
        [Auditing(false)]
        public string Hello([FromBody] IdInput<string> input)
        {
            return repository.Where(t => !t.Name.IsNullOrWhiteSpace()).PageBy(0, 200).FirstOrDefault().Name;
        }
    }
}
