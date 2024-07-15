using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.AboutToDoList.Queries
{
    public class GetAllAboutQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAllAboutQuery, List<About>>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public Task<List<About>> Handle(GetAllAboutQuery request, CancellationToken cancellationToken)
        {
            return _appDbContext.Abouts.ToListAsync(cancellationToken);
        }
    }
}
