using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Application.Models;
using OlmaTech.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.AuthToDoList.Commands
{
    public class LoginCommandHandler(
        IAppDbContext appDbContext,
        ITokenService tokenService,
        IHashService hashService,
        IMapper mapper
        ) : IRequestHandler<LoginCommand, LoginViewModel>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly ITokenService _tokenService = tokenService;
        private readonly IHashService _hashService = hashService;
        private readonly IMapper _mapper = mapper;

        public async Task<LoginViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken)
                                          ?? throw new Exception("User not found");

            if (!_hashService.VerifyHash(request.Password, user.PasswordHash))
            {
                throw new Exception("Login or password incorrect!");
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            if (user.Userrole == UserRole.SuperAdmin)
            {
                foreach(var role in Enum.GetValues(typeof(UserRole)).Cast<UserRole>())
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                }
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, user.Userrole.ToString()));
            }

            return new LoginViewModel()
            {
                User = _mapper.Map<UserViewModel>(user),
                AccessToken = _tokenService.GetAccessToken([.. claims])
            };
        }
    }
}
