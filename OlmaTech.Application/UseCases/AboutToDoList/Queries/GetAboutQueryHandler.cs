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
    public class GetAboutQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAboutQuery, About>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<About> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            var about = await _appDbContext.Abouts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                           ?? throw new Exception("About not found");
            return about;
        }
    }
}
