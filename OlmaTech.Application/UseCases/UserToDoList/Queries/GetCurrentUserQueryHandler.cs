using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.UserToDoList.Queries
{
    public class GetCurrentUserQueryHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService
        ) : IRequestHandler<GetCurrentUserQuery, User>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<User> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.Id, cancellationToken)
                                                ?? throw new Exception("Current User not found");
            return user;
        }
    }
}
