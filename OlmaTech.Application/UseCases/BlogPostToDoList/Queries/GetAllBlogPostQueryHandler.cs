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
    public class GetAllBlogPostQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetAllBlogPostQuery, List<BlogPost>>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<List<BlogPost>> Handle(GetAllBlogPostQuery request, CancellationToken cancellationToken)
        {
            return await _appDbContext.BlogPosts.ToListAsync(cancellationToken);
        }
    }
}
