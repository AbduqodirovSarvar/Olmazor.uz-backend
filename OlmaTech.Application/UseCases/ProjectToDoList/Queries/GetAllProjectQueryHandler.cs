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
    public class GetAllProjectQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAllProjectQuery, List<Project>>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<List<Project>> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
        {
            return await _appDbContext.Projects.ToListAsync(cancellationToken);
        }
    }
}
