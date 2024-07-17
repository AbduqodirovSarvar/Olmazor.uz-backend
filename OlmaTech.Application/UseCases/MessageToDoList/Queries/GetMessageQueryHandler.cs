using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.MessageToDoList.Queries
{
    public class GetMessageQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetMessageQuery, Message>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<Message> Handle(GetMessageQuery request, CancellationToken cancellationToken)
        {
            var message = await _appDbContext.Messages.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                             ?? throw new Exception("Message not found");

            return message;
        }
    }
}
