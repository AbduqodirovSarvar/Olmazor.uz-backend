using Microsoft.AspNetCore.Http;
using OlmaTech.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public Guid Id { get; set; }

        public CurrentUserService(IHttpContextAccessor _contextAccessor)
        {
            var httpContext = _contextAccessor.HttpContext;
            var userClaims = httpContext?.User.Claims;
            var idClaim = userClaims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (idClaim != null && Guid.TryParse(idClaim.Value, out Guid value))
            {
                Id = value;
            }
        }
    }
}
