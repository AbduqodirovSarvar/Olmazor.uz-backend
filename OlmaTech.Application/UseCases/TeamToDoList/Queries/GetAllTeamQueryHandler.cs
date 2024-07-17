using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.TeamToDoList.Queries
{
    public class GetAllTeamQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAllTeamQuery, List<Team>>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<List<Team>> Handle(GetAllTeamQuery request, CancellationToken cancellationToken)
        {
            return await _appDbContext.Teams.ToListAsync(cancellationToken);
        }
    }
}
