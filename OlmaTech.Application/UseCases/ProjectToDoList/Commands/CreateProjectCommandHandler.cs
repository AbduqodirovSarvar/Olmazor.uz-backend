using AutoMapper;
using MediatR;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ProjectToDoList.Commands
{
    public class CreateProjectCommandHandler(
        IAppDbContext appDbContext,
        IMapper mapper,
        IFileService fileService
        ) : IRequestHandler<CreateProjectCommand, Project>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly IMapper _mapper = mapper;
        private readonly IFileService _fileService = fileService;

        public async Task<Project> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var photoFileName = await _fileService.SaveFileAsync(request.Photo)
                                                  ?? throw new Exception("Cannot save the photo");

            var project = _mapper.Map<Project>(request);
            project.Photo = photoFileName;

            await _appDbContext.Projects.AddAsync(project, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return project;
        }
    }
}
