using ArcticFox.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArcticFox.Uow
{
    internal class UnitOfWorkMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly UnitOfWorkManager _unitOfWork;
        public UnitOfWorkMiddleware(UnitOfWorkManager unitOfWork, RequestDelegate next)
        {
            _next = next;
            _unitOfWork = unitOfWork;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            using (var uow = _unitOfWork.Begin())
            {
                try
                {
                    await _next(httpContext);
                    uow.Commit();
                }
                catch (Exception ex)
                {
                    uow.Rollback();
                    throw ex;
                }
            }
        }
    }
}
