using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.AboutToDoList.Commands
{
    public class DeleteAboutCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<DeleteAboutCommand, bool>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<bool> Handle(DeleteAboutCommand request, CancellationToken cancellationToken)
        {
            var about = await _appDbContext.Abouts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                           ?? throw new Exception("About not found");

            _appDbContext.Abouts.Remove(about);
            return (await _appDbContext.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
