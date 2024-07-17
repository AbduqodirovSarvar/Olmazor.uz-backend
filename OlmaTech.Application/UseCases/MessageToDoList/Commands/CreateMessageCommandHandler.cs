using AutoMapper;
using MediatR;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.MessageToDoList.Commands
{
    public class CreateMessageCommandHandler(
        IAppDbContext appDbContext,
        IMapper mapper
        ) : IRequestHandler<CreateMessageCommand, Message>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<Message> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = _mapper.Map<Message>(request);

            await _appDbContext.Messages.AddAsync(message, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return message;
        }
    }
}
