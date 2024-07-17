using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.UserToDoList.Commands
{
    public class DeleteUserCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                          ?? throw new Exception("User not found");

            _appDbContext.Users.Remove(user);
            return (await _appDbContext.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
