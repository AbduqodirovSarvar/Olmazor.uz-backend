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
    public class GetTeamQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetTeamQuery, Team>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<Team> Handle(GetTeamQuery request, CancellationToken cancellationToken)
        {
            var team = await _appDbContext.Teams.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                          ?? throw new Exception("Team not found");
            return team;
        }
    }
}
