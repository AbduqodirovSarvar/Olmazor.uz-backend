using AutoMapper;
using MediatR;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.AboutToDoList.Commands
{
    public class CreateAboutCommandHandler(
        IAppDbContext appDbContext,
        IMapper mapper,
        IFileService fileService
        ) : IRequestHandler<CreateAboutCommand, About>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly IMapper _mapper = mapper;
        private readonly IFileService _fileService = fileService;

        public async Task<About> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            var photoFileName = await _fileService.SaveFileAsync(request.Photo)
                                ?? throw new Exception("Cannot save the photo");

            var about = _mapper.Map<About>(request);

            about.Photo = photoFileName;

            await _appDbContext.Abouts.AddAsync(about, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return about;
        }
    }
}
