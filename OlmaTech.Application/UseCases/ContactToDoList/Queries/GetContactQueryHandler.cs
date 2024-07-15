using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ContactToDoList.Queries
{
    public class GetContactQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetContactQuery, Contact>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<Contact> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var contact = await _appDbContext.Contacts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                              ?? throw new Exception("Contact not found");
            return contact;
        }
    }
}
