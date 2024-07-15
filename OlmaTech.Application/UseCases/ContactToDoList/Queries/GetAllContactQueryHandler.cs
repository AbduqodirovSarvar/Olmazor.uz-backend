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
    public class GetAllContactQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAllContactQuery, List<Contact>>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<List<Contact>> Handle(GetAllContactQuery request, CancellationToken cancellationToken)
        {
            return await _appDbContext.Contacts.ToListAsync(cancellationToken);
        }
    }
}
