using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ProjectToDoList.Queries
{
    public class GetProjectQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetProjectQuery, Project>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<Project> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _appDbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                             ?? throw new Exception("Project not found");
            return project;
        }
    }
}
