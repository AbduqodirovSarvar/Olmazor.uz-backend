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
    public class GetAllMessageQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAllMessageQuery, List<Message>>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<List<Message>> Handle(GetAllMessageQuery request, CancellationToken cancellationToken)
        {
            return await _appDbContext.Messages.ToListAsync(cancellationToken);
        }
    }
}
