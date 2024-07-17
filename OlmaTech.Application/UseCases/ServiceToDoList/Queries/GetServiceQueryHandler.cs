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
    public class GetServiceQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetServiceQuery, Service>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<Service> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var service = await _appDbContext.Services.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                             ?? throw new Exception("Service not found");

            return service;
        }
    }
}
