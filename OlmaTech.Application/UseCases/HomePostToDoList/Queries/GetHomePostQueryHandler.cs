using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.HomePostToDoList.Queries
{
    public class GetHomePostQueryHandler(
        IAppDbContext appDbContext
        ) : IRequestHandler<GetHomePostQuery, HomePost>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<HomePost> Handle(GetHomePostQuery request, CancellationToken cancellationToken)
        {
            var homePost = await _appDbContext.HomePosts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                              ?? throw new Exception("Post not found");
            return homePost;
        }
    }
}
