using AutoMapper;
using MediatR;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ServiceToDoList.Commands
{
    public class CreateServiceCommandHandler(
        IAppDbContext appDbContext,
        IMapper mapper
        ) : IRequestHandler<CreateServiceCommand, Service>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<Service> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = _mapper.Map<Service>(request);

            await _appDbContext.Services.AddAsync(service, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return service;
        }
    }
}
