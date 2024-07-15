using MediatR;
using Microsoft.AspNetCore.Http;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.BlogPostToDoList.Commands
{
    public class CreateBlogPostCommand : IRequest<BlogPost>
    {
        // Title
        public string TitleUz { get; set; } = null!;
        public string TitleEn { get; set; } = null!;
        public string TitleRu { get; set; } = null!;
        public string TitleUzRu { get; set; } = null!;

        // Description
        public string DescriptionUz { get; set; } = null!;
        public string DescriptionEn { get; set; } = null!;
        public string DescriptionRu { get; set; } = null!;
        public string DescriptionUzRu { get; set; } = null!;

        public string? Link { get; set; } = null;

        public IFormFile Photo { get; set; } = null!;
    }
}
