using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.BlogPostToDoList.Queries
{
    public class GetBlogPostQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetBlogPostQuery, BlogPost>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<BlogPost> Handle(GetBlogPostQuery request, CancellationToken cancellationToken)
        {
            var blogPost = await _appDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                           ?? throw new Exception("About not found");
            return blogPost;
        }
    }
}
