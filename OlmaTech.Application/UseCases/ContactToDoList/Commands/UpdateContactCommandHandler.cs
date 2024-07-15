using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ContactToDoList.Commands
{
    public class UpdateContactCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<UpdateContactCommand, Contact>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<Contact> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _appDbContext.Contacts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                             ?? throw new Exception("Contact not found");

            contact.Name = request.Name ?? contact.Name;
            contact.Link = request.Link ?? contact.Link;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return contact;
        }
    }
}
