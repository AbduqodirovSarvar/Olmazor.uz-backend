using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.BlogPostToDoList.Commands
{
    public class UpdateBlogPostCommandHandler(
        IAppDbContext appDbContext,
        IFileService fileService
        ) : IRequestHandler<UpdateBlogPostCommand, BlogPost>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly IFileService _fileService = fileService;

        public async Task<BlogPost> Handle(UpdateBlogPostCommand request, CancellationToken cancellationToken)
        {
            var blogPost = await _appDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                           ?? throw new Exception("About not found");

            if(request.Photo != null)
            {
                var newPhotoName = await _fileService.SaveFileAsync(request.Photo);
                blogPost.Photo = newPhotoName ?? blogPost.Photo;
            }

            blogPost.DescriptionEn = request.DescriptionEn ?? blogPost.DescriptionEn;
            blogPost.DescriptionRu = request.DescriptionRu ?? blogPost.DescriptionRu;
            blogPost.DescriptionUz = request.DescriptionUz ?? blogPost.DescriptionUz;
            blogPost.DescriptionUzRu = request.DescriptionUzRu ?? blogPost.DescriptionUzRu;
            blogPost.TitleEn = request.TitleEn ?? blogPost.TitleEn;
            blogPost.TitleRu = request.TitleRu ?? blogPost.TitleRu;
            blogPost.TitleUz = request.TitleUz ?? blogPost.TitleUz;
            blogPost.TitleUzRu = request.TitleUzRu ?? blogPost.TitleUzRu;
            blogPost.Link = request.Link ?? blogPost.Link;

            await _appDbContext.SaveChangesAsync(cancellationToken);
            return blogPost;
        }
    }
}
