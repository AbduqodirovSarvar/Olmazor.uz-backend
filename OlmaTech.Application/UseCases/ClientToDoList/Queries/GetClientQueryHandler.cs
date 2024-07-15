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
    public class GetClientQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetClientQuery, Client>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<Client> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var client = await _appDbContext.Clients.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                            ?? throw new Exception("Client not found");
            return client;
        }
    }
}
