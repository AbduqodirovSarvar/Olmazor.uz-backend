using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.BlogPostToDoList.Commands
{
    public class DeleteBlogPostCommandHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<DeleteBlogPostCommand, bool>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<bool> Handle(DeleteBlogPostCommand request, CancellationToken cancellationToken)
        {
            var blogPost = await _appDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                           ?? throw new Exception("About not found");

            _appDbContext.BlogPosts.Remove(blogPost);
            return (await _appDbContext.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
