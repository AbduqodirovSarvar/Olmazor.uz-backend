using AutoMapper;
using MediatR;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ContactToDoList.Commands
{
    public class CreateContactCommandHandler(
        IAppDbContext appDbContext,
        IMapper mapper
        ) : IRequestHandler<CreateContactCommand, Contact>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<Contact> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact  = _mapper.Map<Contact>(request);
            await _appDbContext.Contacts.AddAsync(contact, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return contact;
        }
    }
}
