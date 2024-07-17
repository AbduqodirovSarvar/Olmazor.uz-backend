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
    public class GetUserQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetUserQuery, User>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                          ?? throw new Exception("User not found");
            return user;
        }
    }
}
