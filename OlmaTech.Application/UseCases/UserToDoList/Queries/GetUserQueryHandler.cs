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
    public class GetUserQueryHandler(
        IAppDbContext appDbContext,
        IMapper mapper
        ) : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                          ?? throw new Exception("User not found");
            return _mapper.Map<UserViewModel>(user);
        }
    }
}
