using AutoMapper;
using MediatR;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.BlogPostToDoList.Commands
{
    public class CreateBlogPostCommandHandler(
        IAppDbContext appDbContext,
        IMapper mapper,
        IFileService fileService
        ) : IRequestHandler<CreateBlogPostCommand, BlogPost>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly IMapper _mapper = mapper;
        private readonly IFileService _fileService = fileService;

        public async Task<BlogPost> Handle(CreateBlogPostCommand request, CancellationToken cancellationToken)
        {
            
            var photoFileName = await _fileService.SaveFileAsync(request.Photo)
                                ?? throw new Exception("Cannot save the photo");

            var blogPost = _mapper.Map<BlogPost>(request);

            blogPost.Photo = photoFileName;

            await _appDbContext.BlogPosts.AddAsync(blogPost, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return blogPost;
        }
    }
}
