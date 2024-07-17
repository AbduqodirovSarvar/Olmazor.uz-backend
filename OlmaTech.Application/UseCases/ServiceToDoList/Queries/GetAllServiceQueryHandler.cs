using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ServiceToDoList.Queries
{
    public class GetAllServiceQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAllServiceQuery, List<Service>>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<List<Service>> Handle(GetAllServiceQuery request, CancellationToken cancellationToken)
        {
            return await _appDbContext.Services.ToListAsync(cancellationToken);
        }
    }
}
