using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.MessageToDoList.Commands
{
    public class UpdateMessageCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<UpdateMessageCommand, Message>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<Message> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await _appDbContext.Messages.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                             ?? throw new Exception("Message not found");

            message.Email = request.Email ?? message.Email;
            message.Subject = request.Subject ?? message.Subject;
            message.Name = request.Name ?? message.Name;
            message.Text = request.Text ?? message.Text;
            message.IsSeen = request.IsSeen ?? message.IsSeen;
            message.IsReplied = request.IsReplied ?? message.IsReplied;

            await _appDbContext.SaveChangesAsync(cancellationToken);
            throw new NotImplementedException();
        }
    }
}
