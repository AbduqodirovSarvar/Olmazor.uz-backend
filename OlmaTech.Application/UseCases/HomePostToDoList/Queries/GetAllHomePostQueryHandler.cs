using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.HomePostToDoList.Queries
{
    public class GetAllHomePostQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAllHomePostQuery, List<HomePost>>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        public async Task<List<HomePost>> Handle(GetAllHomePostQuery request, CancellationToken cancellationToken)
        {
            return await _appDbContext.HomePosts.ToListAsync(cancellationToken);
        }
    }
}
