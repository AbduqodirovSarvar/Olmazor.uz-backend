using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Application.Models;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.UserToDoList.Queries
{
    public class GetAllUserQueryHandler(
        IAppDbContext appDbContext,
        IMapper mapper
        ) : IRequestHandler<GetAllUserQuery, List<UserViewModel>>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<List<UserViewModel>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
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

            return _mapper.Map<List<UserViewModel>>(users);
        }
    }
}
