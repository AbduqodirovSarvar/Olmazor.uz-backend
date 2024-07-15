using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ClientToDoList.Commands
{
    public class DeleteClientCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<DeleteClientCommand, bool>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<bool> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _appDbContext.Clients.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                           ?? throw new Exception("About not found");

            _appDbContext.Clients.Remove(client);
            return (await _appDbContext.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
