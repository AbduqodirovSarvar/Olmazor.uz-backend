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
    public class GetAllUserQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAllUserQuery, List<User>>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<List<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _appDbContext.Users.ToListAsync(cancellationToken);

            if(request.Gender != null)
            {
                users = users.Where(x => x.Gender == request.Gender).ToList();
            }
            if(request.Role != null)
            {
                users = users.Where(x => x.Userrole == request.Role).ToList();
            }

            return users;
        }
    }
}
