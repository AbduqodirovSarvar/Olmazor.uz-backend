using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.TeamToDoList.Commands
{
    public class DeleteTeamCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<DeleteTeamCommand, bool>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<bool> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await _appDbContext.Teams.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                          ?? throw new Exception("Team not found");

            _appDbContext.Teams.Remove(team);
            return (await _appDbContext.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
