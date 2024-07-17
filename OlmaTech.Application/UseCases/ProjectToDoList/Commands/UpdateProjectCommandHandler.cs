using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Application.Services;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ProjectToDoList.Commands
{
    public class UpdateProjectCommandHandler(
        IAppDbContext appDbContext,
        IFileService fileService
        ) : IRequestHandler<UpdateProjectCommand, Project>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly IFileService _fileService = fileService;

        public async Task<Project> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _appDbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                  ?? throw new Exception("Project not found");

            if (request.Photo != null)
            {
                var photoFileName = await _fileService.SaveFileAsync(request.Photo)
                                                  ?? throw new Exception("Cannot save the photo");
                project.Photo = photoFileName;
            }

            project.NameEn = request.NameEn ?? project.NameEn;
            project.NameRu = request.NameRu ?? project.NameRu;
            project.NameUz = request.NameUz ?? project.NameUz;
            project.NameUzRu = request.NameUzRu ?? project.NameUzRu;
            project.DescriptionEn = request.DescriptionEn ?? project.DescriptionEn;
            project.DescriptionRu = request.DescriptionRu ?? project.DescriptionRu;
            project.DescriptionUz = request.DescriptionUz ?? project.DescriptionUz;
            project.DescriptionUzRu = request.DescriptionUzRu ?? project.DescriptionUzRu;
            project.Link = request.Link ?? project.Link;

            await _appDbContext.SaveChangesAsync(cancellationToken);
            return project;
        }
    }
}
