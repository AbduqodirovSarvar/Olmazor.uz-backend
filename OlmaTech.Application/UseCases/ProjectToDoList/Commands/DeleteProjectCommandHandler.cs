using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ProjectToDoList.Commands
{
    public class DeleteProjectCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<DeleteProjectCommand, bool>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<bool> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _appDbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                              ?? throw new Exception("Project not found");

            _appDbContext.Projects.Remove(project);
            return (await _appDbContext.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
