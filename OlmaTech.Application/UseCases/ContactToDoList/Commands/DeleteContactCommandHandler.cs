using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ContactToDoList.Commands
{
    public class DeleteContactCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<DeleteContactCommand, bool>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<bool> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _appDbContext.Contacts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                             ?? throw new Exception("Contact not found");
            _appDbContext.Contacts.Remove(contact);
            return (await _appDbContext.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
