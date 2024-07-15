using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.HomePostToDoList.Commands
{
    public class DeleteHomePostCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<DeleteHomePostCommand, bool>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<bool> Handle(DeleteHomePostCommand request, CancellationToken cancellationToken)
        {
            var homePost = await _appDbContext.HomePosts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                              ?? throw new Exception("Post not found");

            _appDbContext.HomePosts.Remove(homePost);
            return (await _appDbContext.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
