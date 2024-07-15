using MediatR;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.BlogPostToDoList.Queries
{
    public class GetBlogPostQuery : IRequest<BlogPost>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
