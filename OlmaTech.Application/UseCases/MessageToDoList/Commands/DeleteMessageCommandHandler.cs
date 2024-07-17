using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.MessageToDoList.Commands
{
    public class DeleteMessageCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<DeleteMessageCommand, bool>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<bool> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await _appDbContext.Messages.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                             ?? throw new Exception("Message not found");

            _appDbContext.Messages.Remove(message);
            return (await _appDbContext.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
