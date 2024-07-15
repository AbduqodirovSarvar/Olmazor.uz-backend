using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ClientToDoList.Queries
{
    public class GetAllClientQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAllClientQuery, List<Client>>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<List<Client>> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
        {
            return await _appDbContext.Clients.ToListAsync(cancellationToken);
        }
    }
}
