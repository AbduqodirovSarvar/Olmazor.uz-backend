using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ServiceToDoList.Commands
{
    public class UpdateServiceCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<UpdateServiceCommand, Service>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<Service> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _appDbContext.Services.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                             ?? throw new Exception("Service not found");

            service.NameEn = request.NameEn ?? service.NameEn;
            service.NameRu = request.NameRu ?? service.NameRu;
            service.NameUz = request.NameUz ?? service.NameUz;
            service.NameUzRu = request.NameUzRu ?? service.NameUzRu;
            service.DescriptionEn = request.DescriptionEn ?? service.DescriptionEn;
            service.DescriptionRu = request.DescriptionRu ?? service.DescriptionRu;
            service.DescriptionUz = request.DescriptionUz ?? service.DescriptionUz;
            service.DescriptionUzRu = request.DescriptionUzRu ?? service.DescriptionUzRu;

            await _appDbContext.SaveChangesAsync(cancellationToken);
            return service;
        }
    }
}
