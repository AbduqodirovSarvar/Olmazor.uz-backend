using AutoMapper;
using MediatR;
using OlmaTech.Application.Abstractions;
using OlmaTech.Application.Services;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.HomePostToDoList.Commands
{
    public class CreateHomePostCommandHandler(
        IAppDbContext appDbContext,
        IMapper mapper,
        IFileService fileService
        ) : IRequestHandler<CreateHomePostCommand, HomePost>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly IMapper _mapper = mapper;
        private readonly IFileService _fileService = fileService;

        public async Task<HomePost> Handle(CreateHomePostCommand request, CancellationToken cancellationToken)
        {
            var photoFileName = await _fileService.SaveFileAsync(request.Photo)
                                ?? throw new Exception("Cannot save the photo");
            
            var homePost = _mapper.Map<HomePost>(request);
            homePost.Photo = photoFileName;

            await _appDbContext.HomePosts.AddAsync(homePost, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return homePost;
        }
    }
}
