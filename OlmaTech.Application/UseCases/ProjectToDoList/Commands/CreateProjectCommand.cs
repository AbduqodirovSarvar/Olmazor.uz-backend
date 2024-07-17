using MediatR;
using Microsoft.AspNetCore.Http;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ProjectToDoList.Commands
{
    public class CreateProjectCommand : IRequest<Project>
    {
        // Name 
        public string NameUz { get; set; } = null!;
        public string NameEn { get; set; } = null!;
        public string NameRu { get; set; } = null!;
        public string NameUzRu { get; set; } = null!;

        // Description
        public string DescriptionUz { get; set; } = null!;
        public string DescriptionEn { get; set; } = null!;
        public string DescriptionRu { get; set; } = null!;
        public string DescriptionUzRu { get; set; } = null!;

        public string? Link { get; set; } = null;

        public IFormFile Photo { get; set; } = null!;
    }
}
