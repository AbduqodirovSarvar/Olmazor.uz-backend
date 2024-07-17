using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ServiceToDoList.Commands
{
    public class DeleteServiceCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<DeleteServiceCommand, bool>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<bool> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _appDbContext.Services.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                             ?? throw new Exception("Service not found");

            _appDbContext.Services.Remove(service);
            return (await _appDbContext.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
